using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Commands
{
    public record UpdateSectorCommand(Guid SectorId, UpdateSectorRequest Request) : IRequest<GenericResponse>;
}