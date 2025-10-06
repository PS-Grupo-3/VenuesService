using Application.Interfaces.Query;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class VenueQuery : IVenueQuery
    {
        private readonly AppDbContext _context;

        public VenueQuery(AppDbContext context)
        {
            _context = context;
        }
    }
}
