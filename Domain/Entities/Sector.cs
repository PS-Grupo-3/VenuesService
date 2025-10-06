using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sector
    {
        [Key]
        public Guid SectorId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public bool ControlledSector { get; set; }

        // FK a Venue
        public Guid Venue { get; set; }
        public Venue VenueNavigation { get; set; }

       
    }
}
