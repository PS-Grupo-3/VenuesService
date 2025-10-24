using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Query
{
    public interface ISectorQuery
    {
        Task<IReadOnlyList<Sector>> GetSectorsByVenueIdAsync(Guid venueId, CancellationToken cancellationToken = default);
        Task<Sector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);


    }
}
