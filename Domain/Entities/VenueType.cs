using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VenueType
    {
        [Key]
        public int VenueTypeId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        // Navegación a Venue
        public ICollection<Venue> Venues { get; set; }
    }
}
