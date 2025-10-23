using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Query
{
    public interface IVenueTypeQuery
    {
         Task<IReadOnlyList<VenueType>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<VenueType?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
