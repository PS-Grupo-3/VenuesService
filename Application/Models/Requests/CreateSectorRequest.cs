using System.ComponentModel.DataAnnotations;


namespace Application.Models.Requests
{
    public class CreateSectorRequest
    {
        [Required(ErrorMessage = "El nombre del sector es obligatorio.")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public bool IsControlled { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int? SeatCount { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int? Capacity { get; set; }
        public int? RowNumber { get; set; }
        [Range(int.MinValue, int.MaxValue)]
        public int? ColumnNumber { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int PosX { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int PosY { get; set; }
        [Range(int.MinValue, int.MaxValue)]
        public int Width { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int Height { get; set; }


        [Required]
        public ShapeRequestData Shape { get; set; } = null!;
    }
}