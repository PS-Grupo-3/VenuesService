using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
