using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.VenueType.Queries
{
    public class GetAllVenueTypesHandler : IRequestHandler<GetAllVenueTypesQuery, List<VenueTypeResponse>>
    {
        private readonly IVenueTypeQuery _venueTypeQuery;

        public GetAllVenueTypesHandler(IVenueTypeQuery venueTypeQuery)
        {
            _venueTypeQuery = venueTypeQuery;
        }
        public async Task<List<VenueTypeResponse>> Handle(GetAllVenueTypesQuery request, CancellationToken cancellationToken)
        {
            var venueTypes = await _venueTypeQuery.GetAllAsync(cancellationToken);

            return venueTypes.Select(type => new VenueTypeResponse
            {
                VenueTypeId = type.VenueTypeId,
                Name = type.Name
            }).ToList();
        }
    }
}
