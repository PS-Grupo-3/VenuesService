
namespace Application.Features.Sector.Handlers
{
    using Application.Interfaces.Command;
    using Application.Interfaces.Query;
    using Application.Features.Sector.Commands;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteSectorHandler : IRequestHandler<DeleteSectorCommand, GenericResponse>
    {
 
        private readonly ISectorCommand _sectorCommand;
        private readonly IShapeCommand _shapeCommand;
        private readonly ISectorQuery _sectorQuery;

        public DeleteSectorHandler(
            ISectorCommand sectorCommand,
            IShapeCommand shapeCommand,
            ISectorQuery sectorQuery)
        {
            _sectorCommand = sectorCommand;
            _shapeCommand = shapeCommand;
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

            _shapeCommand.Delete(sector.Shape);

            _sectorCommand.Delete(sector);

            await _sectorCommand.SaveChangesAsync(cancellationToken);

            return new GenericResponse { Success = true, Message = "Sector eliminado correctamente." };
        }
    }
}