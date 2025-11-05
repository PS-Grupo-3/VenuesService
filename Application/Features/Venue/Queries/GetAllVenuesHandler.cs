using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Queries
{
    public class GetAllVenuesHandler : IRequestHandler<GetAllVenuesQuery, IReadOnlyList<VenueResponse>>
    {
        private readonly IVenueQuery _query;

        public GetAllVenuesHandler(IVenueQuery query)
        {
            _query = query;
        }

        public async Task<IReadOnlyList<VenueResponse>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
        {
            var venues = await _query.GetAllAsync(request.Name, request.Location, request.SortByCapacty, request.VenueTypeId, cancellationToken);

            return venues.Select(v => new VenueResponse
            {
                VenueId = v.VenueId,
                Name = v.Name,
                Address = v.Address,
                TotalCapacity = v.TotalCapacity,
                BackgroundImageUrl = v.BackgroundImageUrl,
                VenueType = new VenueTypeResponse
                {
                    VenueTypeId = v.VenueTypeNavigation.VenueTypeId,
                    Name = v.VenueTypeNavigation.Name
                }
            }).ToList();
        }
    }
}