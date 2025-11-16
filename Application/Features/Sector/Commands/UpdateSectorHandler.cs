namespace Application.Features.Sector.Handlers
{
    using Application.Interfaces.Command;
    using Application.Interfaces.Query;
    using Application.Features.Sector.Commands;
    using Application.Models.Responses;
    using Application.Models.Requests;
    using MediatR;

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
                return new GenericResponse { Success = false, Message = "Sector no encontrado." };

            var req = command.Request;
            var shapeDto = req.Shape;
            var shapeEntity = sector.Shape;

            sector.Name = req.Name;
            sector.IsControlled = req.IsControlled;

            if (req.IsControlled)
            {
                if (req.SeatCount is null || req.SeatCount <= 0)
                    throw new ArgumentException("SeatCount debe ser > 0.");

                sector.SeatCount = req.SeatCount;
                sector.Capacity = null;
            }
            else
            {
                if (req.Capacity is null || req.Capacity <= 0)
                    throw new ArgumentException("Capacity debe ser > 0.");

                sector.Capacity = req.Capacity;
                sector.SeatCount = null;
            }

            if (!ValidShapes.Contains(shapeDto.Type.ToLower()))
                throw new ArgumentException($"Shape '{shapeDto.Type}' no permitido.");

            if (shapeDto.Width <= 0 || shapeDto.Height <= 0)
                throw new ArgumentException("Width y Height deben ser > 0.");

            if (shapeDto.Padding < 0)
                throw new ArgumentException("Padding debe ser >= 0.");

            switch (shapeDto.Type.ToLower())
            {
                case "rectangle":
                    if (shapeDto.Rows is null || shapeDto.Columns is null ||
                        shapeDto.Rows <= 0 || shapeDto.Columns <= 0)
                        throw new ArgumentException("Rectangle requiere Rows > 0 y Columns > 0.");
                    break;

                case "circle":
                    if (shapeDto.Rows is null || shapeDto.Columns is null ||
                        shapeDto.Rows <= 0 || shapeDto.Columns <= 0)
                        throw new ArgumentException("Circle requiere Rows > 0 y Columns > 0.");
                    break;

                case "semicircle":
                case "arc":
                    if (shapeDto.Rows is null || shapeDto.Columns is null)
                        throw new ArgumentException("Arc/Semicircle requiere Rows y Columns.");
                    break;
            }

            shapeEntity.Type = shapeDto.Type;
            shapeEntity.Width = shapeDto.Width;
            shapeEntity.Height = shapeDto.Height;
            shapeEntity.X = shapeDto.X;
            shapeEntity.Y = shapeDto.Y;
            shapeEntity.Rotation = shapeDto.Rotation;
            shapeEntity.Padding = shapeDto.Padding;
            shapeEntity.Opacity = shapeDto.Opacity;
            shapeEntity.Colour = shapeDto.Colour ?? "#ffffff";
            shapeEntity.Rows = shapeDto.Rows;
            shapeEntity.Columns = shapeDto.Columns;

            _sectorCommand.Update(sector);
            await _sectorCommand.SaveChangesAsync(cancellationToken);

            return new GenericResponse
            {
                Success = true,
                Message = "Sector actualizado correctamente."
            };
        }
    }
}
