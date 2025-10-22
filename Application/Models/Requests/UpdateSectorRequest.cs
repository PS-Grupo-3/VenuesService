using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class UpdateSectorRequest
    {
        [Required]
        public string Name { get; set; }
        public bool isControlled { get; set; }
        [Range(0,  int.MaxValue)]
        public int? SeatCount { get; set; }
        [Range(0, int.MaxValue)]
        public int? Capacity { get; set; }

    }
}
