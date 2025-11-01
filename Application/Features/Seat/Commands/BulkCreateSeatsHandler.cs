using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Features.Seat.Commands;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Application.Features.Seat.Handlers
{
    public class BulkCreateSeatsHandler : IRequestHandler<BulkCreateSeatsCommand>
    {
        private readonly ISeatCommand _seatCommand;
        private readonly ISectorQuery _sectorQuery;

        public BulkCreateSeatsHandler(ISeatCommand seatCommand, ISectorQuery sectorQuery)
        {
            _seatCommand = seatCommand;
            _sectorQuery = sectorQuery;
        }

        public async Task<Unit> Handle(BulkCreateSeatsCommand command, CancellationToken cancellationToken)
        {
       
            var sector = await _sectorQuery.GetByIdAsync(command.SectorId, cancellationToken);
            if (sector == null)
            {
                throw new KeyNotFoundException("El sector especificado no existe.");
            }
            if (!sector.IsControlled)
            {
                throw new InvalidOperationException("No se pueden crear asientos en un sector no controlado.");
            }

      
            foreach (var seatDto in command.Request.Seats)
            {
                var seat = new Domain.Entities.Seat
                {
                    SectorId = command.SectorId,
                    RowNumber = seatDto.RowNumber,
                    ColumnNumber = seatDto.ColumnNumber,
                    PosX = seatDto.PosX,
                    PosY = seatDto.PosY
                };

                await _seatCommand.InsertAsync(seat, cancellationToken);
            }

            // --- 3. CORRECCIÓN AQUÍ ---
            // Añadir el 'return' que requiere Task<Unit>
            return Unit.Value;
        }
    }
}