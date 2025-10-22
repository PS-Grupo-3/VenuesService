using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Commands
{
    public class UpdateSeatHandler : IRequestHandler<UpdateSeatCommand, GenericResponse>
    {
        public Task<GenericResponse> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}