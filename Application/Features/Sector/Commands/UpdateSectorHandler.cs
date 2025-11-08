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
        
        private static readonly HashSet<string> ValidShapes = new()
        {
            "rectangle", "circle", "semicircle", "arc"
        };
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
            sector.Width = command.Request.Width;
            sector.Height = command.Request.Height;
            sector.RowNumber = command.Request.RowNumber;
            sector.ColumnNumber = command.Request.ColumnNumber;

            if (command.Request.Width <= 0 && command.Request.Height <= 0)
            {
                throw new ArgumentException($"El ancho y alto deben ser positivos.");
            }

            if (command.Request.Width <= 0 || command.Request.Height <= 0)
            {
                throw new ArgumentException($"Ingrese medidas válidas.");
            }

            if (!sector.IsControlled && command.Request.Capacity <= 0)
            {
                throw new ArgumentException($"Ingrese una capacidad válida.");
            }
            if (sector.IsControlled && command.Request.SeatCount <= 0)
            {
                throw new ArgumentException($"Ingrese una cantidad de asientos válida.");
            }

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


            if (!ValidShapes.Contains(command.Request.Shape.Type.ToLower()))
                throw new ArgumentException($"Shape '{command.Request.Shape.Type}' no permitido. Los válidos son: {string.Join(", ", ValidShapes)}");


            var shapeEntity = sector.Shape;
            var shapeDto = command.Request.Shape;

            if (shapeDto.Width < 0 && shapeDto.Height < 0)
            {
                throw new ArgumentException($"El ancho y alto tiene que ser positivos.");
            }
            if (shapeDto.Width <= 0 || shapeDto.Height <= 0)
            {
                throw new ArgumentException($"Ingrese medidas válidas.");
            }
            if (shapeDto.Padding <= 0)
            {
                throw new ArgumentException($"Ingrese un padding válido.");
            }



            shapeEntity.Type = shapeDto.Type;
            shapeEntity.Width = shapeDto.Width;
            shapeEntity.Height = shapeDto.Height;
            shapeEntity.X = shapeDto.X;
            shapeEntity.Y = shapeDto.Y;
            shapeEntity.Rotation = shapeDto.Rotation;
            shapeEntity.Padding = shapeDto.Padding;
            shapeEntity.Opacity = shapeDto.Opacity;
            shapeEntity.Colour = shapeDto.Colour;

            // Update sector position based on shape position
            sector.PosX = shapeDto.X;
            sector.PosY = shapeDto.Y;

            _sectorCommand.Update(sector);

            await _sectorCommand.SaveChangesAsync(cancellationToken);

            return new GenericResponse { Success = true, Message = "Sector actualizado correctamente." };
        }
    }
}