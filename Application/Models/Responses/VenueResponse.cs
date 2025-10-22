using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class VenueResponse
    {
        public Guid VenueId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int TotalCapacity { get; set; }
        public string VenueTypeName { get; set; }
    }
}
