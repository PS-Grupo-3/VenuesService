using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class ArcSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        return new List<Seat>
        {
            new Seat { RowNumber = 1, ColumnNumber = 1, PosX = 30, PosY = 25, SectorId = sector.SectorId }
        };
    }
}