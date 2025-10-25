using System.ComponentModel.DataAnnotations;

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
