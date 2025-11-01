using System.Collections.Generic;

namespace Application.Models.Responses
{
    public class SectorDetailResponse
    {
        public Guid SectorId { get; set; } // <-- Solo una vez
        public string Name { get; set; } = string.Empty;
        public bool IsControlled { get; set; }
        public int? SeatCount { get; set; }
        public int? Capacity { get; set; }
        public Guid VenueId { get; set; }
        public ShapeResponse Shape { get; set; } = null!;
        public List<SeatResponse> Seats { get; set; } = new();
        public int SectorWidth { get; set; }
        public int SectorHeight { get; set; }
        public int? RowNumber { get; set; }
        public int? ColumnNumber { get; set; }
    }
}