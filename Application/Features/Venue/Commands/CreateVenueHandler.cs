
using Application.Features.Venue.Commands;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Commands
{
    public class CreateVenueHandler : IRequestHandler<CreateVenueCommand, VenueResponse>
    {
        public Task<VenueResponse> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}