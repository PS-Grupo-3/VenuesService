namespace Application.Features.Sector.Handlers
{
    using Application.Interfaces.Query;
    using Application.Features.Sector.Queries;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq; 
    using System.Collections.Generic; 

    public class GetSectorByIdHandler : IRequestHandler<GetSectorByIdQuery, SectorDetailResponse>
    {
        private readonly ISectorQuery _sectorQuery;

        public GetSectorByIdHandler(ISectorQuery sectorQuery)
        {
            _sectorQuery = sectorQuery;
        }

        public async Task<SectorDetailResponse> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
        {
 
            var sector = await _sectorQuery.GetByIdAsync(request.SectorId, cancellationToken);

            if (sector == null)
            {
                throw new KeyNotFoundException("No se encontró un Sector con ese ID");
            }

            if (sector.Name == null)
            {
                throw new KeyNotFoundException("No se encontró un Sector con ese Nombre.");
            }

            return new SectorDetailResponse
            {
                SectorId = sector.SectorId,
                Name = sector.Name,
                IsControlled = sector.IsControlled,
                SeatCount = sector.SeatCount,
                Capacity = sector.Capacity,
                VenueId = sector.Venue,
                PosX = sector.PosX,
                PosY = sector.PosY,
                SectorWidth = sector.Width,
                SectorHeight = sector.Height,
                RowNumber = sector.RowNumber,
                ColumnNumber = sector.ColumnNumber,

                Shape = new ShapeResponse
                {
                    ShapeId = sector.Shape.ShapeId,
                    Type = sector.Shape.Type,
                    Width = sector.Shape.Width,
                    Height = sector.Shape.Height,
                    X = sector.Shape.X,
                    Y = sector.Shape.Y,
                    Rotation = sector.Shape.Rotation,
                    Padding = sector.Shape.Padding,
                    Opacity = sector.Shape.Opacity,
                    Colour = sector.Shape.Colour
                },

                Seats = sector.Seats.Select(seat => new SeatResponse
                {
                    SeatId = seat.SeatId,
                    RowNumber = seat.RowNumber,
                    ColumnNumber = seat.ColumnNumber,
                    PosX = seat.PosX,
                    PosY = seat.PosY
                }).ToList(),

            };
        }
    }
}