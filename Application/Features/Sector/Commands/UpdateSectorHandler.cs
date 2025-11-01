// 1. Namespace corregido
namespace Application.Features.Sector.Handlers
{
    using Application.Interfaces.Command;
    using Application.Interfaces.Query;
    using Application.Features.Sector.Commands;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateSectorHandler : IRequestHandler<UpdateSectorCommand, GenericResponse>
    {
        private readonly ISectorCommand _sectorCommand;
        private readonly ISectorQuery _sectorQuery;

        public UpdateSectorHandler(ISectorCommand sectorCommand, ISectorQuery sectorQuery)
        {
            _sectorCommand = sectorCommand;
            _sectorQuery = sectorQuery;
        }

        public async Task<GenericResponse> Handle(UpdateSectorCommand command, CancellationToken cancellationToken)
        {
            var sector = await _sectorQuery.GetByIdAsync(command.SectorId, cancellationToken);

            if (sector == null)
            {
                return new GenericResponse { Success = false, Message = "Sector no encontrado." };
            }

            sector.Name = command.Request.Name;
            sector.IsControlled = command.Request.IsControlled;

            if (sector.IsControlled)
            {
                sector.SeatCount = command.Request.SeatCount;
                sector.Capacity = null;
            }
            else
            {
                sector.Capacity = command.Request.Capacity;
                sector.SeatCount = null;
            }

            var shapeEntity = sector.Shape; 
            var shapeDto = command.Request.Shape;

            shapeEntity.Type = shapeDto.Type;
            shapeEntity.Width = shapeDto.Width;
            shapeEntity.Height = shapeDto.Height;
            shapeEntity.X = shapeDto.X;
            shapeEntity.Y = shapeDto.Y;
            shapeEntity.Rotation = shapeDto.Rotation;
            shapeEntity.Padding = shapeDto.Padding;
            shapeEntity.Opacity = shapeDto.Opacity;
            shapeEntity.Colour = shapeDto.Colour;


            _sectorCommand.Update(sector);

            await _sectorCommand.SaveChangesAsync(cancellationToken);

            return new GenericResponse { Success = true, Message = "Sector actualizado correctamente." };
        }
    }
}