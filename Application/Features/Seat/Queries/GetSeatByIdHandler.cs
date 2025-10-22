using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Queries
{
    public class GetSeatByIdHandler : IRequestHandler<GetSeatByIdQuery, SeatDetailResponse>
    {
        public Task<SeatDetailResponse> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}