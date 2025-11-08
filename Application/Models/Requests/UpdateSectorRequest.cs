
using System.ComponentModel.DataAnnotations;


namespace Application.Models.Requests
{
    public class UpdateSectorRequest
    {
        [Required(ErrorMessage = "El nombre del sector es obligatorio.")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public bool IsControlled { get; set; }

        [Range(0, int.MaxValue)]
        public int? SeatCount { get; set; }

        [Range(0, int.MaxValue)]
        public int? Capacity { get; set; }

        [Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }
        
        public int? RowNumber { get; set; }   
        public int? ColumnNumber { get; set; }

        [Required]
        public ShapeRequestData Shape { get; set; } = null!;
    }
}