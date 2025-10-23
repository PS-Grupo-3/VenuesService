using Application.Features.Seat.Commands;
using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Commands
{
    public record DeleteSeatCommand(DeleteSeatRequest request) : IRequest<GenericResponse>;
}