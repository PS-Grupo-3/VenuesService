using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Commands
{
    public record UpdateSectorCommand(UpdateSectorRequest Request) : IRequest<GenericResponse>;
}