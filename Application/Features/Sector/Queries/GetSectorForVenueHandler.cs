using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sector.Queries
{
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
                SeatCount = s.SeatCount
               
            }).ToList();
        }
    }
}

