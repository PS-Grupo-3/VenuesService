// 1. Namespace corregido
namespace Application.Features.Sector.Handlers
{
    using Application.Features.Sector.Commands;
    using Application.Interfaces.Command;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using SectorEntity = Domain.Entities.Sector;
    using ShapeEntity = Domain.Entities.Shape; 

    public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, SectorResponse>
    {

        private readonly ISectorCommand _sectorCommand;
        private readonly IShapeCommand _shapeCommand;

        public CreateSectorHandler(ISectorCommand sectorCommand, IShapeCommand shapeCommand)
        {
            _sectorCommand = sectorCommand;
            _shapeCommand = shapeCommand;
        }

        public async Task<SectorResponse> Handle(CreateSectorCommand command, CancellationToken cancellationToken)
        {

            var shape = new ShapeEntity
            {
                Type = command.Request.Shape.Type,
                Width = command.Request.Shape.Width,
                Height = command.Request.Shape.Height,
                X = command.Request.Shape.X,
                Y = command.Request.Shape.Y,
                Rotation = command.Request.Shape.Rotation,
                Padding = command.Request.Shape.Padding,
                Opacity = command.Request.Shape.Opacity,
                Colour = command.Request.Shape.Colour
            };


            await _shapeCommand.InsertAsync(shape, cancellationToken);

            var sector = new SectorEntity
            {
                Name = command.Request.Name,
                IsControlled = command.Request.IsControlled,
                Venue = command.VenueId, 
                SeatCount = command.Request.IsControlled ? command.Request.SeatCount : null,
                Capacity = !command.Request.IsControlled ? command.Request.Capacity : null,
                Shape = shape 
            };

            await _sectorCommand.InsertAsync(sector, cancellationToken);

            await _sectorCommand.SaveChangesAsync(cancellationToken);


            return new SectorResponse
            {
                SectorId = sector.SectorId,
                Name = sector.Name,
                IsControlled = sector.IsControlled,
                SeatCount = sector.SeatCount,
                Capacity = sector.Capacity,
                Shape = new ShapeResponse 
                {
                    ShapeId = shape.ShapeId,
                    Type = shape.Type,
                    Width = shape.Width,
                    Height = shape.Height,
                    X = shape.X,
                    Y = shape.Y,
                    Rotation = shape.Rotation,
                    Padding = shape.Padding,
                    Opacity = shape.Opacity,
                    Colour = shape.Colour
                }
            };
        }
    }
}