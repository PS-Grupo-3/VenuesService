using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class SeatResponse
    {
        public long SeatId { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
    }
}
