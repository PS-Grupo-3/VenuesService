﻿using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface ISectorCommand
    {
        Task InsertAsync(Sector sector, CancellationToken cancellationToken = default);

        void Delete(Sector sector);

        void Update(Sector sector);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}