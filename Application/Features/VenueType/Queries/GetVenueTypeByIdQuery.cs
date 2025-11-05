using Application.Models.Responses;
using MediatR;

namespace Application.Features.VenueType.Queries
{
    public record GetVenueTypeByIdQuery(int TypeId) :IRequest<VenueTypeResponse>
    {
    }
}
