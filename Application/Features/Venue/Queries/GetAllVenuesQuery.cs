using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Queries
{
    public record GetAllVenuesQuery() : IRequest<List<VenueResponse>>;
}