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
        public string? Name { get; set; }
        public long TotalCapacity { get; set; }
        public string? Address { get; set; }
        public string? MapUrl { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public VenueTypeResponse? VenueType { get; set; }
        public List<SectorResponse>? Sectors { get; set; }
    }
}
