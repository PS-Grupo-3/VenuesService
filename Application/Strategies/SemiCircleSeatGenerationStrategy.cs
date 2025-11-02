using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class SemiCircleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        return new List<Seat>
        {
            new Seat { RowNumber = 1, ColumnNumber = 1, PosX = 15, PosY = 15, SectorId = sector.SectorId }
        };
    }
}