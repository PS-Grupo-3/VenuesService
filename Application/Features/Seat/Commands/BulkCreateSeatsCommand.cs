using Application.Models.Requests;
using MediatR;
using System;

namespace Application.Features.Seat.Commands
{
    public record BulkCreateSeatsCommand(
        Guid SectorId,
        BulkCreateSeatsRequest Request
    ) : IRequest; 
}