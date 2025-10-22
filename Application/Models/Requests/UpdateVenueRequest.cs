using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class UpdateVenueRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public int TotalCapacity { get; set; }
        public int VenueTypeId { get; set; }
        public string? Address { get; set; }
        public string? MapUrl { get; set; }

    }
}
