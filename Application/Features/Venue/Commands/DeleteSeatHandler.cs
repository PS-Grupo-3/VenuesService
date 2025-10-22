using Application.Interfaces;
using Application.Features.Venue.Commands;
using Application.Models.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Venue.Commands
{
    public class DeleteSeatHandler : IRequestHandler<DeleteSeatCommand, GenericResponse>
    {
        public Task<GenericResponse> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
