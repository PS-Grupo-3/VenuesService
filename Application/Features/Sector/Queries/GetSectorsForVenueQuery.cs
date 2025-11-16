using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Queries
{
    public record GetSectorsForVenueQuery(Guid VenueId): IRequest<IEnumerable<SectorResponse>>;
}
