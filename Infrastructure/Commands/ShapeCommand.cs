using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class ShapeCommand : IShapeCommand
    {
        private readonly AppDbContext _context;

        public ShapeCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Shape shape, CancellationToken cancellationToken = default)
        {
            await _context.Shapes.AddAsync(shape, cancellationToken);
        }

        public void Update(Shape shape)
        {
            _context.Shapes.Update(shape);
        }

        public void Delete(Shape shape)
        {
            _context.Shapes.Remove(shape);
        }
    }
}