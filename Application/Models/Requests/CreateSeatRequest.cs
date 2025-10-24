using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreateSeatRequest
    {
        [Required]
        public Guid SectorId { get; set; }

        [Range(1, int.MaxValue)]
        public int RowNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int ColumnNumber { get; set; }
    }
}