using Application.Interfaces.Query;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
   public class VenueTypeQuery : IVenueTypeQuery
    {
        private readonly AppDbContext _context;

        public VenueTypeQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<VenueType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.VenueTypes
                 .AsNoTracking()
                 .ToListAsync(cancellationToken);
        }

        public async Task<VenueType?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.VenueTypes.FindAsync(id, cancellationToken);
        }
    }
}
