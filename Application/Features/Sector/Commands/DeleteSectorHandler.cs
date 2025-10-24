using Application.Interfaces;
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Sector.Commands
{
    public class DeleteSectorHandler : IRequestHandler<DeleteSectorCommand, GenericResponse>
    {
        private readonly ISectorCommand _sectorCommand;
        private readonly ISectorQuery _sectorQuery;

        public DeleteSectorHandler(ISectorCommand sectorCommand, ISectorQuery sectorQuery)
        {
            _sectorCommand = sectorCommand;
            _sectorQuery = sectorQuery;
        }

        public async Task<GenericResponse> Handle(DeleteSectorCommand command, CancellationToken cancellationToken)
        {
            var sectorId = command.request.SectorId;

            var sector = await _sectorQuery.GetByIdAsync(sectorId, cancellationToken);

            if (sector == null)
            {
                return new GenericResponse { Success = false, Message = "Sector no encontrado." };
            }

            await _sectorCommand.DeleteAsync(sector, cancellationToken);

            // 4. Devuelve la respuesta
            return new GenericResponse { Success = true, Message = "Sector eliminado correctamente." };
        }
    }
}