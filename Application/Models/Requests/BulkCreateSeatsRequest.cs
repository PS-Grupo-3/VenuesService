using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class BulkCreateSeatsRequest
    {
        public List<SeatDefinition> Seats { get; set; } = new();
    }

    public class SeatDefinition
    {
        [Range(1, int.MaxValue)]
        public int RowNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int ColumnNumber { get; set; }

        [Range(0, int.MaxValue)]
        public int PosX { get; set; } 

        [Range(0, int.MaxValue)]
        public int PosY { get; set; } 
    }
}