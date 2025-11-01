using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Seat
    {
        [Key]
        public long SeatId { get; set; }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        public int ColumnNumber { get; set; }

        [Required]
        public int PosX { get; set; }

        [Required]
        public int PosY { get; set; }

        [ForeignKey("SectorNavigation")]
        public Guid SectorId { get; set; }
        public Sector SectorNavigation { get; set; } = null!;
    }
}