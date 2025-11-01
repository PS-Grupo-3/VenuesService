namespace Application.Models.Responses
{
    public class SeatResponse
    {
        public long SeatId { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

    }
}