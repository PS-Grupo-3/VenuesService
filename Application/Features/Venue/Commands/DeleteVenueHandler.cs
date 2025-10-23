using Application.Interfaces;
using Application.Features.Venue.Commands;
using Application.Models.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Command;
using Application.Interfaces.Query;

namespace Application.Features.Venue.Commands
{
    public class DeleteVenueHandler : IRequestHandler<DeleteVenueCommand, GenericResponse>
    {
        private readonly IVenueCommand _venueCommand;
        private readonly IVenueQuery _venueQuery;

        public DeleteVenueHandler(IVenueCommand venueCommand, IVenueQuery venueQuery)
        {
            _venueCommand = venueCommand;
            _venueQuery = venueQuery;
        }

      
        public async Task<GenericResponse> Handle(DeleteVenueCommand command, CancellationToken cancellationToken)
        {

            var venueId = command.request.VenueId;

      
            var venue = await _venueQuery.GetByIdAsync(venueId, cancellationToken);

            if (venue == null)
            {
                return new GenericResponse { Success = false, Message = "Venue no encontrado." };
            }


            await _venueCommand.DeleteAsync(venue, cancellationToken);

            return new GenericResponse { Success = true, Message = "Venue eliminado correctamente." };
        }
    }
}