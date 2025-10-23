using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VenueType.Queries
{
    public class GetVenueTypeByIdHandler : IRequestHandler<GetVenueTypeByIdQuery, VenueTypeResponse>
    {
        private readonly IVenueTypeQuery _venueTypeQuery;

        public GetVenueTypeByIdHandler(IVenueTypeQuery venueTypeQuery)
        {
            _venueTypeQuery = venueTypeQuery;
        }

        public async Task<VenueTypeResponse> Handle(GetVenueTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var type = await _venueTypeQuery.GetByIdAsync(request.TypeId, cancellationToken);

            if (type == null)

                throw new KeyNotFoundException("No se encontró un tipo con ese ID");


            return new VenueTypeResponse
            {
                VenueTypeId = type.VenueTypeId,
                Name = type.Name
            };
        }
    }
}
