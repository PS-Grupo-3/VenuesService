using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venue
    {
        [Key]
        public Guid VenueId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Location { get; set; }
        public long TotalCapacity { get; set; }

        public string Address { get; set; }

        public string MapUrl { get; set; }

        // FK a VenueType
        public int VenueType { get; set; }

        
        public VenueType VenueTypeNavigation { get; set; }

        // Navegación a Sector
        public ICollection<Sector> Sectors { get; set; }
    }
}
