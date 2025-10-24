using Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sector.Queries
{
    public record GetSectorsForVenueQuery(Guid VenueId): IRequest<IEnumerable<SectorResponse>>;
}
