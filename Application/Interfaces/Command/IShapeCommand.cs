using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface IShapeCommand
    {
        Task InsertAsync(Shape shape, CancellationToken cancellationToken = default);
        void Update(Shape shape);
        void Delete(Shape shape);
    }
}
