using Domain.Entities;


namespace Application.Interfaces.Query
{
    public interface ISectorQuery
    {
        Task<IReadOnlyList<Sector>> GetSectorsByVenueIdAsync(Guid venueId, CancellationToken cancellationToken = default);
        Task<Sector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);


    }
}
