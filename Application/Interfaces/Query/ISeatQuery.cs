using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface ISeatQuery
    {
        Task<Seat?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Seat>> GetSeatsBySectorIdAsync(Guid sectorId, CancellationToken cancellationToken = default);
    }
}