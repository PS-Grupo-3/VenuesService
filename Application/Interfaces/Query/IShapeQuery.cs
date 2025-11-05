using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IShapeQuery
    {
        Task<IReadOnlyList<Shape>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Shape?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
