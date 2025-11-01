using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class SectorCommand : ISectorCommand
    {
        private readonly AppDbContext _context;

        public SectorCommand(AppDbContext context)
        {
            _context = context;
        }


        public async Task InsertAsync(Sector sector, CancellationToken cancellationToken = default)
        {
            await _context.Sectors.AddAsync(sector, cancellationToken);
        }

        public void Update(Sector sector)
        {
            _context.Sectors.Update(sector);
        }

        public void Delete(Sector sector)
        {
            _context.Sectors.Remove(sector);
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}