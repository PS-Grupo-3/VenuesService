using Application.Interfaces;
using Application.Models.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Sector.Commands
{
    public class DeleteSectorHandler : IRequestHandler<DeleteSectorCommand, GenericResponse>
    {
        public Task<GenericResponse> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
