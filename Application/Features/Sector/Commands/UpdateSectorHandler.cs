using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Commands
{
    public class UpdateSectorHandler : IRequestHandler<UpdateSectorCommand, GenericResponse>
    {
        public Task<GenericResponse> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}