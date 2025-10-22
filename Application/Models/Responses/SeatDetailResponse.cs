using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class SeatDetailResponse
    {
        public long SeatId { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        public Guid SectorId { get; set; }
        public string SectorName { get; set; } 

        public Guid VenueId { get; set; }
        public string VenueName { get; set; } 
    }
}
