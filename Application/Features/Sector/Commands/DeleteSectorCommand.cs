using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Commands
{
    public record DeleteSectorCommand(DeleteSectorRequest request) : IRequest<GenericResponse>;
}