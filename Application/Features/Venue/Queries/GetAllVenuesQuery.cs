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
        public int? TotalCapacity { get; }
        public int? VenueTypeId { get; }
        public string Address { get; }
        public string? MapUrl { get; }

        public SortDirection? SortByCapacty { get; }

        public GetAllVenuesQuery(string? name, string? location, int? totalCapacity, int? venueTypeId, string? address, string? mapUrl, SortDirection? sortByCapacity)
        {
            Name = name;
            Location = location;
            TotalCapacity = totalCapacity;
            VenueTypeId = venueTypeId;
            Address = address;
            MapUrl = mapUrl;
            SortByCapacty = sortByCapacity;
        }
    }
}

