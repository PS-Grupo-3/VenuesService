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

    public class UpdateSectorShapeHandler : IRequestHandler<UpdateSectorShapeCommand, GenericResponse>
    {
        private readonly ISectorQuery _sectorQuery;
        private readonly ISectorCommand _sectorCommand;

        public UpdateSectorShapeHandler(ISectorQuery sectorQuery, ISectorCommand sectorCommand)
        {
            _sectorQuery = sectorQuery;
            _sectorCommand = sectorCommand;
        }

        public async Task<GenericResponse> Handle(UpdateSectorShapeCommand command, CancellationToken ct)
        {
 
            var sector = await _sectorQuery.GetByIdAsync(command.SectorId, ct);
            if (sector == null)
            {
                return new GenericResponse { Success = false, Message = "Sector no encontrado." };
            }

      
            var shape = sector.Shape; 
            shape.Type = command.Request.Type;
            shape.Width = command.Request.Width;
            shape.Height = command.Request.Height;
            shape.X = command.Request.X;
            shape.Y = command.Request.Y;
            shape.Rotation = command.Request.Rotation;
            shape.Padding = command.Request.Padding;
            shape.Opacity = command.Request.Opacity;
            shape.Colour = command.Request.Colour;

  
            _sectorCommand.Update(sector);

            await _sectorCommand.SaveChangesAsync(ct);

            return new GenericResponse { Success = true, Message = "Forma del sector actualizada." };
        }
    }
}