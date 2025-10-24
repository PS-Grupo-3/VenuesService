using Application.Interfaces.Command;
using Application.Models.Responses;
using MediatR;


namespace Application.Features.Sector.Commands
{
    public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, SectorResponse>
    {
        private readonly ISectorCommand _sectorCommand;

        public CreateSectorHandler(ISectorCommand sectorCommand)
        {
            _sectorCommand = sectorCommand;
        }

        public async Task<SectorResponse> Handle(CreateSectorCommand command, CancellationToken cancellationToken)
        {
            var sector = new Domain.Entities.Sector
            {
                Name = command.Request.Name,
                IsControlled = command.Request.isControlled,
                Venue = command.id, 
                SeatCount = command.Request.isControlled ? command.Request.SeatCount : null,
                Capacity = !command.Request.isControlled ? command.Request.Capacity : null
            };

            await _sectorCommand.InsertAsync(sector, cancellationToken);

            return new SectorResponse
            {
                SectorId = sector.SectorId,
                Name = sector.Name,
                IsControlled = sector.IsControlled,
                SeatCount = sector.SeatCount,
                Capacity = sector.Capacity
            };
        }
    }
}