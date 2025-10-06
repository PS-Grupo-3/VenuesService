using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ControlledSector : Sector
    {
        public long SeatCount { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
