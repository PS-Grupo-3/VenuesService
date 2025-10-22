using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class VenueDetailResponse
    {
        public Guid VenueId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int TotalCapacity { get; set; }
        public string? Adress { get; set; }
        public string? MapUrl { get; set; }
        public string VenueTypeName { get; set; }
        public List<SectorResponse> Sectors { get; set; }
    }
}
