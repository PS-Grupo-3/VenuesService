using Application.Interfaces.Query;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Queries
{
    public class SeatQuery : ISeatQuery
    {
        private readonly AppDbContext _context;

        public SeatQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Seat?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _context.Seats
                .Include(seat => seat.SectorNavigation)
                .ThenInclude(sector => sector.VenueNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SeatId == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Seat>> GetSeatsBySectorIdAsync(Guid sectorId, CancellationToken cancellationToken = default)
        {
            return await _context.Seats
                .Where(s => s.SectorId == sectorId) 
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}