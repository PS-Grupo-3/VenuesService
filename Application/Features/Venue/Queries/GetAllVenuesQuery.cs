using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Venue.Queries
{
    public record GetAllVenuesQuery : IRequest<IReadOnlyList<VenueResponse>>
    {
        public string? Name { get; }
        public string? Location { get; }
        public int? VenueTypeId { get; }
        public SortDirection? SortByCapacty { get; }

        public GetAllVenuesQuery(string? name, string? location, int? venueTypeId, SortDirection? sortByCapacity)
        {
            Name = name;
            Location = location;
            VenueTypeId = venueTypeId;
            SortByCapacty = sortByCapacity;
        }
    }
}

