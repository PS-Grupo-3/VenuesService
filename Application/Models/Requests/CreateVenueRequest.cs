
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreateVenueRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int TotalCapacity { get; set; }
        [Required]
        public int VenueTypeId { get; set; }
        [Required]
        public string? Address { get; set; }

        public string? MapUrl { get; set; }
    }
}
