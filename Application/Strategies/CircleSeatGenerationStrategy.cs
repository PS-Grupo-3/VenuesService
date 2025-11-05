using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class CircleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        return new List<Seat>
        {
            new Seat { RowNumber = 1, ColumnNumber = 1, PosX = 5, PosY = 5, SectorId = sector.SectorId },
            new Seat { RowNumber = 1, ColumnNumber = 2, PosX = 10, PosY = 5, SectorId = sector.SectorId }
        };
    }
}