using Application.Interfaces.Query;
using Application.Features.Seat.Queries;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Handlers
{
    public class GetSeatsBySectorIdHandler : IRequestHandler<GetSeatsBySectorIdQuery, IReadOnlyList<SeatResponse>>
    {
        private readonly ISeatQuery _seatQuery;

        public GetSeatsBySectorIdHandler(ISeatQuery seatQuery)
        {
            _seatQuery = seatQuery;
        }

        public async Task<IReadOnlyList<SeatResponse>> Handle(GetSeatsBySectorIdQuery request, CancellationToken cancellationToken)
        {
            var seats = await _seatQuery.GetSeatsBySectorIdAsync(request.SectorId, cancellationToken);

      
            return seats.Select(s => new SeatResponse
            {
                SeatId = s.SeatId,
                RowNumber = s.RowNumber,
                ColumnNumber = s.ColumnNumber,
                PosX = s.PosX,
                PosY = s.PosY  
            }).ToList();
        }
    }
}