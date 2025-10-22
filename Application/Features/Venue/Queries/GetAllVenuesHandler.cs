using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Queries
{
    public class GetAllVenuesHandler : IRequestHandler<GetAllVenuesQuery, List<VenueResponse>>
    {
        public Task<List<VenueResponse>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}