using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Seat.Commands
{
    public class CreateSeatHandler : IRequestHandler<CreateSeatCommand, SeatResponse>
    {
        private readonly ISeatCommand _seatCommand;
        private readonly ISectorQuery _sectorQuery;

        public CreateSeatHandler(ISeatCommand seatCommand, ISectorQuery sectorQuery)
        {
            _seatCommand = seatCommand;
            _sectorQuery = sectorQuery;
        }

        public async Task<SeatResponse> Handle(CreateSeatCommand command, CancellationToken cancellationToken)
        {
            var request = command.Request;

            var sector = await _sectorQuery.GetByIdAsync(request.SectorId, cancellationToken);

            if (sector == null)
            {
                throw new KeyNotFoundException("El sector especificado no existe.");
            }

            if (!sector.IsControlled)
            {
                throw new InvalidOperationException("No se pueden crear asientos individuales en un sector no controlado.");
            }

            var seat = new Domain.Entities.Seat
            {
                SectorId = request.SectorId,
                RowNumber = request.RowNumber,
                ColumnNumber = request.ColumnNumber
            };

            await _seatCommand.InsertAsync(seat, cancellationToken);


            return new SeatResponse
            {
                SeatId = seat.SeatId,
                RowNumber = seat.RowNumber,
                ColumnNumber = seat.ColumnNumber
            };
        }
    }
}