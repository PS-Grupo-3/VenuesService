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
        private static readonly HashSet<string> ValidShapes = new()
        {
            "rectangle", "circle", "semicircle", "arc"
        };
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

            if (!ValidShapes.Contains(command.Request.Type.ToLower()))
                throw new ArgumentException($"Shape '{command.Request.Type}' no permitido. Los válidos son: {string.Join(", ", ValidShapes)}");


            if (command.Request.Width < 0 && command.Request.Height < 0)
            {
                throw new ArgumentException($"El ancho y alto deben ser positivos.");
            }

            if (command.Request.Width <= 0 || command.Request.Height <= 0)
            {
                throw new ArgumentException($"Ingrese medidas válidas.");
            }
            if (command.Request.Padding <= 0)
            {
                throw new ArgumentException($"Ingrese un padding válido.");
            }



            var shape = sector.Shape; 
            shape.Type = command.Request.Type;
            shape.Width = command.Request.Width;
            shape.Height = command.Request.Height;
            shape.X = command.Request.X;
            shape.Y = command.Request.Y;
            shape.Rows = command.Request.Rows ?? 5;
            shape.Columns = command.Request.Columns ?? 5;
            shape.Rotation = command.Request.Rotation;
            shape.Padding = command.Request.Padding;
            shape.Opacity = command.Request.Opacity;
            shape.Colour = command.Request.Colour ?? "#ffffff";

  
            _sectorCommand.Update(sector);

            await _sectorCommand.SaveChangesAsync(ct);

            return new GenericResponse { Success = true, Message = "Forma del sector actualizada." };
        }
    }
}