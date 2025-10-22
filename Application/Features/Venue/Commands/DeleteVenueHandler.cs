using Application.Features.Venue.Commands;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Event.Commands
{
    public class DeleteVenueHandler : IRequestHandler<DeleteVenueCommand>
    {
        public async Task Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}