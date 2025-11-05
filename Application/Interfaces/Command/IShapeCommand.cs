using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IShapeCommand
    {
        Task InsertAsync(Shape shape, CancellationToken cancellationToken = default);
        void Update(Shape shape);
        void Delete(Shape shape);
    }
}
