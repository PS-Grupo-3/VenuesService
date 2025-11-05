
namespace Application.Features.Seat.Handlers
{
    using Application.Interfaces.Command;
    using Application.Interfaces.Query;
    using Application.Features.Seat.Commands;
    using Application.Models.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteSeatHandler : IRequestHandler<DeleteSeatCommand, GenericResponse>
    {
        private readonly ISeatCommand _seatCommand;
        private readonly ISeatQuery _seatQuery;

        public DeleteSeatHandler(ISeatCommand seatCommand, ISeatQuery seatQuery)
        {
            _seatCommand = seatCommand;
            _seatQuery = seatQuery;
        }

        public async Task<GenericResponse> Handle(DeleteSeatCommand command, CancellationToken cancellationToken)
        {
   
            var seatId = command.request.SeatId;

            var seat = await _seatQuery.GetByIdAsync(seatId, cancellationToken);

            if (seat == null)
            {
                return new GenericResponse { Success = false, Message = "Asiento no encontrado." };
            }

     
            await _seatCommand.DeleteAsync(seat, cancellationToken);


            return new GenericResponse { Success = true, Message = "Asiento eliminado correctamente." };
        }
    }
}