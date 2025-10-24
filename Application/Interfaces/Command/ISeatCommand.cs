using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface ISeatCommand
    {
        Task InsertAsync(Seat seat, CancellationToken cancellationToken = default);
        Task UpdateAsync(Seat seat, CancellationToken cancellationToken = default);
        Task DeleteAsync(Seat seat, CancellationToken cancellationToken = default);
    }
}