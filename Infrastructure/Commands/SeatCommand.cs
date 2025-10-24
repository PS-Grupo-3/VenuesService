using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class SeatCommand : ISeatCommand
    {
        private readonly AppDbContext _context;

        public SeatCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Seat seat, CancellationToken cancellationToken = default)
        {
            await _context.Seats.AddAsync(seat, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Seat seat, CancellationToken cancellationToken = default)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Seat seat, CancellationToken cancellationToken = default)
        {
            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}