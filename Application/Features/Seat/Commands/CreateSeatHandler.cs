using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Commands
{
    public class CreateSeatHandler : IRequestHandler<CreateSeatCommand, SeatResponse>
    {
        public Task<SeatResponse> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}