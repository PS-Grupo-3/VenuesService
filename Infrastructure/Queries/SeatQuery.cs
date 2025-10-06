using Application.Interfaces.Query;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class SeatQuery : ISeatQuery
    {
        private readonly AppDbContext _context;

        public SeatQuery(AppDbContext context)
        {
            _context = context;
        }
    }
}
