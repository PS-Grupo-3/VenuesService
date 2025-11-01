namespace Application.Models.Responses
{
    public class SeatDetailResponse
    {
        public long SeatId { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Guid SectorId { get; set; }
        public string SectorName { get; set; } = string.Empty;

        public Guid VenueId { get; set; }
        public string VenueName { get; set; } = string.Empty;
    }
}