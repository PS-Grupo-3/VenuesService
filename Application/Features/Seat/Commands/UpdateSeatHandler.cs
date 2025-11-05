
namespace Application.Features.Seat.Handlers
{
    using Application.Interfaces.Command;
    using Application.Interfaces.Query;
    using Application.Features.Seat.Commands;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateSeatHandler : IRequestHandler<UpdateSeatCommand, GenericResponse>
    {
        private readonly ISeatCommand _seatCommand;
        private readonly ISeatQuery _seatQuery;

        public UpdateSeatHandler(ISeatCommand seatCommand, ISeatQuery seatQuery)
        {
            _seatCommand = seatCommand;
            _seatQuery = seatQuery;
        }

        public async Task<GenericResponse> Handle(UpdateSeatCommand command, CancellationToken cancellationToken)
        {
            var seat = await _seatQuery.GetByIdAsync(command.SeatId, cancellationToken);

            if (seat == null)
            {
                return new GenericResponse { Success = false, Message = "Asiento no encontrado." };
            }

            seat.RowNumber = command.Request.RowNumber;
            seat.ColumnNumber = command.Request.ColumnNumber;
            seat.PosX = command.Request.PosX; 
            seat.PosY = command.Request.PosY; 

            await _seatCommand.UpdateAsync(seat, cancellationToken);

            return new GenericResponse { Success = true, Message = "Asiento actualizado correctamente." };
        }
    }
}