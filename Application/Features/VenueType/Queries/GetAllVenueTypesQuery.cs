using Application.Models.Responses;
using MediatR;

namespace Application.Features.VenueType.Queries
{
    public class GetAllVenueTypesQuery() : IRequest<List<VenueTypeResponse>>
    {
    }
}
