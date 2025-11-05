    using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Sector
    {
        [Key]
        public Guid SectorId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public bool IsControlled { get; set; }

        public int? SeatCount { get; set; }

        public int? Capacity { get; set; }
        public int? RowNumber { get; set; }
        public int? ColumnNumber { get; set; }
        public int? PosX { get; set; }
        public int? PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // FK a Venue
        public Guid Venue { get; set; }
        public Venue VenueNavigation { get; set; }

        public Shape Shape { get; set; } = null!;
        public ICollection<Seat> Seats { get; set; }


    }
}