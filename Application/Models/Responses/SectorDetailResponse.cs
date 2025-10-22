﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class SectorDetailResponse
    {
        public Guid SectorId { get; set; }
        public string Name { get; set; }
        public bool IsControlled { get; set; }
        public int? SeatCount { get; set; }
        public int? Capacity { get; set; }

        public Guid VenueId { get; set; } 
        public string VenueName { get; set; }

        public List<SeatResponse> Seats { get; set; }
    }
}
