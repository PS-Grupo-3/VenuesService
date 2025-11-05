using Application.Models.Requests;
using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IVenueQuery
    {
        Task<IReadOnlyList<Venue>> GetAllAsync(string? name, string? address, SortDirection? sortByCapacity, int? typeId, CancellationToken cancellationToken = default);
        Task<Venue?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
