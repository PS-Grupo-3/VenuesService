
namespace Application.Features.Sector.Handlers
{
    using Application.Interfaces.Query;
    using Application.Features.Sector.Queries;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq; 
    using System.Collections.Generic;

    public class GetSectorsForVenueHandler
    : IRequestHandler<GetSectorsForVenueQuery, IEnumerable<SectorResponse>>
    {
        private readonly ISectorQuery _sectorQuery;

        public GetSectorsForVenueHandler(ISectorQuery sectorQuery)
        {
            _sectorQuery = sectorQuery;
        }

        public async Task<IEnumerable<SectorResponse>> Handle(GetSectorsForVenueQuery request, CancellationToken ct)
        {
            var sectors = await _sectorQuery.GetSectorsByVenueIdAsync(request.VenueId, ct);

            return sectors.Select(s => new SectorResponse
            {
                SectorId = s.SectorId,
                Name = s.Name,
                Capacity = s.Capacity,
                IsControlled = s.IsControlled,
                SeatCount = s.SeatCount,

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
            }).ToList();
        }
    }
}