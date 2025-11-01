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
    public class SectorQuery : ISectorQuery
    {
        private readonly AppDbContext _context;

        public SectorQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Sector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sectors
                .Include(s => s.Seats)           
                .Include(s => s.Shape)           
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectorId == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Sector>> GetSectorsByVenueIdAsync(Guid venueId, CancellationToken cancellationToken = default)
        {
            return await _context.Sectors
                .Include(s => s.Shape)
                .Where(s => s.Venue == venueId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        
    }
}
