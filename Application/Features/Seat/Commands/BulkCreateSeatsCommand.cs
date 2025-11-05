using Application.Models.Requests;
using MediatR;

namespace Application.Features.Seat.Commands
{
    public record BulkCreateSeatsCommand(
        Guid SectorId,
        BulkCreateSeatsRequest Request
    ) : IRequest; 
}