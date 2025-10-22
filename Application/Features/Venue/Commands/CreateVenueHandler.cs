using Application.Models.Responses;
using MediatR;

namespace Application.Features.Event.Commands
{
    public class CreateEventHandler : IRequestHandler<CreateVenueCommand, VenueResponse>
    {
        public Task<VenueResponse> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}