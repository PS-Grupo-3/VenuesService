using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Queries
{
    public record GetSeatsBySectorIdQuery(Guid SectorId) : IRequest<IReadOnlyList<SeatResponse>>;
}