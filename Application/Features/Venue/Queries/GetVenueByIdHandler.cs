using Application.Interfaces.Query;
using Application.Models.Responses;
using Domain.Entities;
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
                    RowNumber = s.RowNumber,
                    ColumnNumber = s.ColumnNumber,
                    PosX = s.PosX,
                    PosY = s.PosY, 
                    Width = s.Width,
                    Height = s.Height,
                    Shape = new ShapeResponse
                    {
                        ShapeId = s.Shape.ShapeId,
                        Type = s.Shape.Type,
                        Width = s.Shape.Width,
                        Height = s.Shape.Height,
                        X = s.Shape.X,
                        Y = s.Shape.Y,
                        Rotation = s.Shape.Rotation,
                        Padding = s.Shape.Padding,
                        Opacity = s.Shape.Opacity,
                        Colour = s.Shape.Colour
                    }                                                                
                }).ToList()

            };
        }
    }
}