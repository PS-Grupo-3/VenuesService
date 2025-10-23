using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface IVenueCommand
    {
        Task InsertAsync(Venue venue, CancellationToken cancellationToken = default);
        Task UpdateAsync(Venue venue, CancellationToken cancellationToken = default);
        Task DeleteAsync(Venue venue, CancellationToken cancellationToken = default);
    }
}
