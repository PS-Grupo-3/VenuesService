using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class RectangleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        if (sector.RowNumber is null || sector.ColumnNumber is null)
            throw new InvalidOperationException("Rectángulo requiere RowNumber y ColumnNumber definidos.");

        var seats = new List<Seat>();

        int rows = sector.RowNumber.Value;
        int cols = sector.ColumnNumber.Value;

        int baseX = sector.PosX.Value;
        int baseY = sector.PosY.Value;
        int spacingX = 5;
        int spacingY = 5;
        int padding = sector.Shape.Padding;

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                seats.Add(new Seat
                {
                    SectorId = sector.SectorId,
                    RowNumber = row,
                    ColumnNumber = col,
                    PosX = baseX + ((col - 1) * spacingX) + padding,
                    PosY = baseY + ((row - 1) * spacingY) + padding
                });
            }
        }

        return seats;
    }
}
