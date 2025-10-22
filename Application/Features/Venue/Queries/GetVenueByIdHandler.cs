using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Queries
{
    public class GetVenueByIdHandler : IRequestHandler<GetVenueByIdQuery, VenueDetailResponse>
    {
        public Task<VenueDetailResponse> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}