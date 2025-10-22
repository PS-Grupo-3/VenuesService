using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Commands
{
    public class UpdateVenueCommand : IRequestHandler<UpdateVenueCommad, GenericResponse>
    {
        public Task<GenericResponse> Handle(UpdateVenueCommad request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}