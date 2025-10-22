using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Queries
{
    public record GetAllSeatsQuery() : IRequest<List<SeatResponse>>;
}