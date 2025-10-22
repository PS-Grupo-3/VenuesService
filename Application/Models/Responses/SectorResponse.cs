using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class SectorResponse
    {
        public Guid SectorId { get; set; }
        public string Name { get; set; }
        public bool IsControlled { get; set; } 
        public int? SeatCount { get; set; }
        public int? Capacity { get; set; }
    }
}
