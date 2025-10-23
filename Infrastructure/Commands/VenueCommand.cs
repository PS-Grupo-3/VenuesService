using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class VenueCommand : IVenueCommand
    {
        private readonly AppDbContext _context;

        public VenueCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Venue venue, CancellationToken cancellationToken = default)
        {
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(Venue venue, CancellationToken cancellationToken = default)
        {
            await _context.Venues.AddAsync(venue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Venue venue, CancellationToken cancellationToken = default)
        {
            _context.Entry(venue).Property(v => v.VenueType).IsModified = true;
            _context.Venues.Update(venue);
            await _context.SaveChangesAsync();
        }
    }
}
