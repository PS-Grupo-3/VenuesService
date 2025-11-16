namespace Application.Features.Sector.Handlers
{
    using Application.Features.Sector.Commands;
    using Application.Interfaces.Command;
    using Application.Models.Responses;
    using MediatR;
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

        private static readonly HashSet<string> ValidShapes = new()
        {
            "rectangle", "circle", "semicircle", "arc"
        };

        public async Task<SectorResponse> Handle(CreateSectorCommand command, CancellationToken cancellationToken)
        {
            var req = command.Request;

            if (!ValidShapes.Contains(req.Shape.Type.ToLower()))
                throw new ArgumentException($"Shape '{req.Shape.Type}' no permitido. Válidos: {string.Join(", ", ValidShapes)}");

            if (req.Shape.Width <= 0 || req.Shape.Height <= 0)
                throw new ArgumentException("Width y Height deben ser positivos.");

            if (req.Shape.Padding < 0)
                throw new ArgumentException("Padding debe ser >= 0.");

            if (req.IsControlled)
            {
                if (req.Shape.Rows is null || req.Shape.Columns is null)
                    throw new ArgumentException("Rectangle requiere Rows y Columns en Shape.");

                if (req.Shape.Rows <= 0 || req.Shape.Columns <= 0)
                    throw new ArgumentException("Rows y Columns deben ser > 0.");

                if (req.SeatCount <= 0)
                    throw new ArgumentException("SeatCount debe ser > 0.");
            }
            else
            {
                if (req.Capacity is null || req.Capacity <= 0)
                    throw new ArgumentException("Capacity debe ser > 0 para sectores NO controlados.");
            }

            var shape = new ShapeEntity
            {
                Type = req.Shape.Type,
                Width = req.Shape.Width,
                Height = req.Shape.Height,
                X = req.Shape.X,
                Y = req.Shape.Y,
                Rotation = req.Shape.Rotation,
                Padding = req.Shape.Padding,
                Opacity = req.Shape.Opacity,
                Colour = req.Shape.Colour ?? "#ffffff",

                Rows = req.Shape.Rows,
                Columns = req.Shape.Columns,                
            };

            await _shapeCommand.InsertAsync(shape, cancellationToken);

            var sector = new SectorEntity
            {
                Name = req.Name,
                IsControlled = req.IsControlled,
                Venue = command.VenueId,
                SeatCount = req.IsControlled ? req.SeatCount : null,
                Capacity = req.IsControlled ? null : req.Capacity,
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
                    Width = shape.Width ?? 0,
                    Height = shape.Height ?? 0,
                    X = shape.X ?? 0,
                    Y = shape.Y ?? 0,
                    Rows = shape.Rows ?? 5,
                    Cols = shape.Rows ?? 5,
                    Rotation = shape.Rotation ?? 0,
                    Padding = shape.Padding ?? 0,
                    Opacity = shape.Opacity ?? 0,
                    Colour = shape.Colour ?? "#ffffff"
                }
            };
        }
    }
}
