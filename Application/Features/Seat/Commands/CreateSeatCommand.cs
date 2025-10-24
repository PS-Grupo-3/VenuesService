using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Commands
{
    public record CreateSeatCommand(CreateSeatRequest Request) : IRequest<SeatResponse>;
}