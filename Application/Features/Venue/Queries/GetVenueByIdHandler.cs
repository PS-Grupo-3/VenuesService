using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Queries
{
    public class GetVenueByIdHandler : IRequestHandler<GetVenueByIdQuery, VenueDetailResponse>
    {
        public IVenueQuery _venueQuery;

        public GetVenueByIdHandler(IVenueQuery venueQuery)
        {
            _venueQuery = venueQuery;
        }

        public async Task<VenueDetailResponse> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
        {
            var venue = await _venueQuery.GetByIdAsync(request.Id, cancellationToken);

            if (venue == null)
            {
                throw new KeyNotFoundException("No se encontró un Venue con ese ID");
            }

            return new VenueDetailResponse
            {
                VenueId = venue.VenueId,
                Name = venue.Name,
                Location = venue.Location,
                TotalCapacity = venue.TotalCapacity,
                Adress = venue.Address,
                MapUrl = venue.MapUrl,
                VenueType = new VenueTypeResponse
                {
                    VenueTypeId = venue.VenueTypeNavigation.VenueTypeId,
                    Name = venue.VenueTypeNavigation.Name
                },

                Sectors = venue.Sectors.Select(s => new SectorResponse
                {
                    SectorId = s.SectorId,
                    Name = s.Name,
                    IsControlled = s.IsControlled,
                    SeatCount = s.SeatCount,
                    Capacity = s.Capacity
                }).ToList()

            };
        }
    }
}