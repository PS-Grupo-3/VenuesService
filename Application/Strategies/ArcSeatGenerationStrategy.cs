using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class ArcSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        if (sector.RowNumber is null || sector.ColumnNumber is null)
            throw new InvalidOperationException("Rectángulo requiere RowNumber y ColumnNumber definidos.");

        int rows = sector.RowNumber.Value;
        int cols = sector.ColumnNumber.Value;

        int totalSeats = rows * cols;
        var seats = new Seat[totalSeats];

        int baseX = sector.PosX ?? 0;
        int baseY = sector.PosY ?? 0;
        int spacingX = 5;
        int spacingY = 5;
        int padding = sector.Shape.Padding;

        int index = 0;

        for (int row = 1; row <= rows; row++)
        {
            int posY = baseY + ((row - 1) * spacingY) + padding;

            for (int col = 1; col <= cols; col++)
            {
                int posX = baseX + ((col - 1) * spacingX) + padding;

                seats[index++] = new Seat
                {
                    SectorId = sector.SectorId,
                    RowNumber = row,
                    ColumnNumber = col,
                    PosX = posX,
                    PosY = posY
                };
            }
        }

        return seats;
    }
}