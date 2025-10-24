using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Commands
{
    public class UpdateSectorHandler : IRequestHandler<UpdateSectorCommand, GenericResponse>
    {
        private readonly ISectorCommand _sectorCommand;
        private readonly ISectorQuery _sectorQuery;

        public UpdateSectorHandler(ISectorCommand sectorCommand, ISectorQuery sectorQuery)
        {
            _sectorCommand = sectorCommand;
            _sectorQuery = sectorQuery;
        }

        public async Task<GenericResponse> Handle(UpdateSectorCommand command, CancellationToken cancellationToken)
        {
            var sector = await _sectorQuery.GetByIdAsync(command.SectorId, cancellationToken);

            if (sector == null)
            {
                return new GenericResponse { Success = false, Message = "Sector no encontrado." };
            }
            sector.Name = command.Request.Name;
            sector.IsControlled = command.Request.isControlled;

            if (sector.IsControlled)
            {
                sector.SeatCount = command.Request.SeatCount;
                sector.Capacity = null;
            }
            else
            {
                sector.Capacity = command.Request.Capacity;
                sector.SeatCount = null;
            }
            await _sectorCommand.UpdateAsync(sector, cancellationToken);

            return new GenericResponse { Success = true, Message = "Sector actualizado correctamente." };
        }
    }
}