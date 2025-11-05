using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Commands
{
    public class UpdateVenueHandler : IRequestHandler<UpdateVenueCommand, GenericResponse>
    {

        private readonly IVenueCommand _venueCommand;
        private readonly IVenueQuery _venueQuery;

        public UpdateVenueHandler(IVenueCommand venueCommand, IVenueQuery venueQuery)
        {
            _venueCommand = venueCommand;
            _venueQuery = venueQuery;
        }

        public async Task<GenericResponse> Handle(UpdateVenueCommand command, CancellationToken cancellationToken)
        {
 
            var venue = await _venueQuery.GetByIdAsync(command.VenueId, cancellationToken);

            if (venue == null)
            {
                return new GenericResponse { Success = false, Message = "Venue no encontrado." };
            }

            venue.Name = command.Request.Name;
            venue.TotalCapacity = command.Request.TotalCapacity;
            venue.VenueTypeNavigation.VenueTypeId = command.Request.VenueTypeId;
            venue.Address = command.Request.Address;
            venue.MapUrl = command.Request.MapUrl;
            venue.BackgroundImageUrl = command.Request.BackgroundImageUrl;
            await _venueCommand.UpdateAsync(venue, cancellationToken);

            return new GenericResponse { Success = true, Message = "Venue actualizado correctamente." };
        }
    }
}