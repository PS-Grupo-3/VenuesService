using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Queries
{
    public class GetAllSeatsHandler : IRequestHandler<GetAllSeatsQuery, List<SeatResponse>>
    {
        public Task<List<SeatResponse>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}