using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Commands
{
    public record UpdateSeatCommand(long SeatId, UpdateSeatRequest Request) : IRequest<GenericResponse>;
}