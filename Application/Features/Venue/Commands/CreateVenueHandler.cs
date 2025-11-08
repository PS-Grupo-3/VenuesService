
using Application.Features.Venue.Commands;
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Commands
{
    public class CreateVenueHandler : IRequestHandler<CreateVenueCommand, VenueResponse>
    {
        private readonly IVenueCommand _venueCommand;
        private readonly IVenueTypeQuery _venueTypeQuery;

        public CreateVenueHandler(IVenueCommand venueCommand, IVenueTypeQuery venueTypeQuery)
        {
            _venueCommand = venueCommand;
            _venueTypeQuery = venueTypeQuery;
        }





        // 4. Lógica de "Handle" implementada
        public async Task<VenueResponse> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
        {
            var type = await _venueTypeQuery.GetByIdAsync(request.Request.VenueTypeId, cancellationToken);
            if (type == null)
            {
                throw new KeyNotFoundException("No existe un tipo con ese ID");
            }

            if (request.Request.TotalCapacity <= 0) 
            {
                throw new ArgumentException("Ingrese una capacidad válida");
            }




            var venue = new Domain.Entities.Venue
            {
                VenueId = Guid.NewGuid(),
                VenueType = request.Request.VenueTypeId,
                Address = request.Request.Address,
                Name = request.Request.Name,
                MapUrl = request.Request.MapUrl,
                TotalCapacity = request.Request.TotalCapacity,
                BackgroundImageUrl = request.Request.BackgroundImageUrl,


            };

            await _venueCommand.InsertAsync(venue, cancellationToken);

            return new VenueResponse
            {
                VenueId = venue.VenueId,
                Name = venue.Name,
                Address = venue.Address,
                TotalCapacity = venue.TotalCapacity,
                BackgroundImageUrl = venue.BackgroundImageUrl,
                VenueType = new VenueTypeResponse
                {
                    VenueTypeId = type.VenueTypeId,
                    Name = type.Name

                }
            };

        }
    }
}