using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface ISectorCommand
    {
        Task InsertAsync(Sector sector, CancellationToken cancellationToken = default);

        Task DeleteAsync(Sector sector, CancellationToken cancellationToken = default);

        Task UpdateAsync(Sector sector, CancellationToken cancellationToken = default);

    }
}
