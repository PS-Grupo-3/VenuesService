using Application.Features.Seat.Queries;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

public class GetSeatByIdHandler : IRequestHandler<GetSeatByIdQuery, SeatDetailResponse>
{
    private readonly ISeatQuery _seatQuery;
    public GetSeatByIdHandler(ISeatQuery seatQuery) { _seatQuery = seatQuery; }

    public async Task<SeatDetailResponse> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
    {
        var seat = await _seatQuery.GetByIdAsync(request.SeatId, cancellationToken);

        if (seat == null)
        {
            
            return null;
        }

        return new SeatDetailResponse
        {
            SeatId = seat.SeatId,
            RowNumber = seat.RowNumber,
            ColumnNumber = seat.ColumnNumber,
            PosX = seat.PosX,
            PosY = seat.PosY,
            SectorId = seat.SectorId,
            SectorName = seat.SectorNavigation.Name,
            VenueId = seat.SectorNavigation.VenueNavigation.VenueId,
            VenueName = seat.SectorNavigation.VenueNavigation.Name
        };
    }
}