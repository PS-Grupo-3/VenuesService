using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Query
{
    public interface IShapeQuery
    {
        Task<IReadOnlyList<Shape>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Shape?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
