using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required]
        public ShapeRequestData Shape { get; set; } = null!;
    }
}