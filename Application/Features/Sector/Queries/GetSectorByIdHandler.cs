using Application.Features.Sector.Queries;
using Application.Features.Seat.Queries;
using Application.Models.Responses;
using MediatR;
using Application.Interfaces.Query;

namespace Application.Features.Sector.Queries
{
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

            return new SectorDetailResponse
            {
                SectorId = sector.SectorId,
                Name = sector.Name,
                IsControlled = sector.IsControlled,
                SeatCount = sector.SeatCount,
                Capacity = sector.Capacity,
                VenueId = sector.Venue,
                Seats = sector.Seats.Select(seat => new SeatResponse
                {
                    SeatId = seat.SeatId,
                    RowNumber = seat.RowNumber,
                    ColumnNumber = seat.ColumnNumber
                }).ToList()
            };
        }
    }
}