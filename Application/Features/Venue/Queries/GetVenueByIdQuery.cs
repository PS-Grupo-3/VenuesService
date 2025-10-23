using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Queries
{
    public record GetVenueByIdQuery(Guid Id) : IRequest<VenueDetailResponse>;
}