using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Query
{
    public interface ISeatQuery
    {
        Task<Seat?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Seat>> GetSeatsBySectorIdAsync(Guid sectorId, CancellationToken cancellationToken = default);
    }
}