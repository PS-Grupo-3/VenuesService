using Domain.Entities;

namespace Application.Interfaces.Strategies
{
    public interface ISeatGenerationStrategy
    {
        IEnumerable<Seat> GenerateSeats(Sector sector);
    }
}



