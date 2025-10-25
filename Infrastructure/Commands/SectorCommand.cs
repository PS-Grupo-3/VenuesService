using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class SectorCommand : ISectorCommand
    {
        private readonly AppDbContext _context;

        public SectorCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Sector sector, CancellationToken cancellationToken = default)
        {
            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertAsync(Sector sector, CancellationToken cancellationToken = default)
        {
            await _context.Sectors.AddAsync(sector, cancellationToken);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Sector sector, CancellationToken cancellationToken = default)
        {
            _context.Sectors.Update(sector);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
