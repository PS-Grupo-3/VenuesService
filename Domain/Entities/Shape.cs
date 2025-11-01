using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Shape
    {
        [Key]
        public int ShapeId { get; set; }

        [Required]
        public string Type { get; set; } = null!;
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; } 
        public int Y { get; set; } 
        public int Rotation { get; set; } 
        public int Padding { get; set; }
        public int Opacity { get; set; }
        public string Colour { get; set; } = "#FFFFFF";


        [ForeignKey("Sector")]
        public Guid SectorId { get; set; }
        public Sector Sector { get; set; } = null!;
    }
}