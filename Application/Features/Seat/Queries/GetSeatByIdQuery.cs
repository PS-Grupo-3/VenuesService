using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Queries
{
    public record GetSeatByIdQuery(Guid SeatId) : IRequest<SeatDetailResponse>;
}