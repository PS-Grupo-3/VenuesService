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
    public class ShapeQuery : IShapeQuery
    {
        private readonly AppDbContext _context;

        public ShapeQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Shape>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Shapes
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Shape?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Shapes
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ShapeId == id, cancellationToken);
        }
    }
}
