using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Seat
    {
        [Key]
        public long SeatId { get; set; }

        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        // FK a Sector
        public Guid SectorId { get; set; }
        public Sector SectorNavigation { get; set; }
    }
}
