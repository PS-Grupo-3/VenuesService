using Application.Interfaces.Query;
using Application.Models.Requests;
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
    public class VenueQuery : IVenueQuery
    {
        private readonly AppDbContext _context;

        public VenueQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Venue?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Venues
                .Include(v => v.VenueTypeNavigation)
                .Include(v => v.Sectors)
                    .ThenInclude(s => s.Shape)
                .Include(v => v.Sectors)
                    .ThenInclude(s => s.Seats)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VenueId == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Venue>> GetAllAsync(
            string? name,
            string? address,
            SortDirection? sortByCapacity,
            int? typeId,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Venues
                .Include(v => v.VenueTypeNavigation)
                .AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(v => v.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(v => v.Address.Contains(address));
            }

            if (typeId.HasValue)
            {
                query = query.Where(v => v.VenueType == typeId.Value);
            }

            if (sortByCapacity.HasValue)
            {
                query = sortByCapacity == SortDirection.asc
                    ? query.OrderBy(v => v.TotalCapacity)
                    : query.OrderByDescending(v => v.TotalCapacity);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
    }
