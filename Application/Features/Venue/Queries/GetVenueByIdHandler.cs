using Application.Interfaces.Query;
using Application.Models.Responses;
using Domain.Entities;
using MediatR;

#pragma warning disable CS8602, CS8604
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
                TotalCapacity = venue.TotalCapacity,
                Address = venue.Address,
                MapUrl = venue.MapUrl,
                BackgroundImageUrl = venue.BackgroundImageUrl,
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
                    Capacity = s.Capacity,                    
                    Shape = new ShapeResponse
                    {
                        ShapeId = s.Shape.ShapeId,
                        Type = s.Shape.Type,
                        Width = s.Shape.Width  ?? 0,
                        Height = s.Shape.Height ?? 0,
                        X = s.Shape.X ?? 0,
                        Y = s.Shape.Y ?? 0,
                        Rows = s.Shape.Rows ?? 0,
                        Cols = s.Shape.Columns ?? 0,
                        Rotation = s.Shape.Rotation ?? 0,
                        Padding = s.Shape.Padding ?? 0,
                        Opacity = s.Shape.Opacity ?? 0,
                        Colour = s.Shape.Colour
                    }                                                                
                }).ToList()

            };
        }
    }
}