using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface ISeatCommand
    {
        Task InsertAsync(Seat seat, CancellationToken cancellationToken = default);


        Task UpdateAsync(Seat seat, CancellationToken cancellationToken = default);

        Task DeleteAsync(Seat seat, CancellationToken cancellationToken = default);
        Task DeleteBySectorIdAsync(Guid sectorId, CancellationToken cancellationToken = default);
    }
}