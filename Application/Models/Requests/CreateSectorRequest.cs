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

        [Required]
        public ShapeRequest Shape { get; set; } = null!;
    }
}