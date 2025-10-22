using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Commands
{
    public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, SectorResponse>
    {
        public Task<SectorResponse> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}