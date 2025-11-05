using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IVenueTypeQuery
    {
         Task<IReadOnlyList<VenueType>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<VenueType?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
