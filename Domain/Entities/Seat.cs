using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Seat
    {
        [Key]
        public long SeatId { get; set; }

        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        // FK a Sector
        public Guid ControlledSector { get; set; }
        public ControlledSector ControlledSectorNavigation { get; set; }
    }
}
