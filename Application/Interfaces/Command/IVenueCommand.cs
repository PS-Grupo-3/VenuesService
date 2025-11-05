using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IVenueCommand
    {
        Task InsertAsync(Venue venue, CancellationToken cancellationToken = default);
        Task UpdateAsync(Venue venue, CancellationToken cancellationToken = default);
        Task DeleteAsync(Venue venue, CancellationToken cancellationToken = default);
    }
}
