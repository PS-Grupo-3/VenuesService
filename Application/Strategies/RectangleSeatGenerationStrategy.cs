using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class RectangleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        var shape = sector.Shape;

        if (shape.Rows is null || shape.Columns is null)
            throw new InvalidOperationException("Rectangle requiere Rows y Columns definidos en Shape.");

        int rows = shape.Rows.Value;
        int cols = shape.Columns.Value;

        int spacingX = 5;
        int spacingY = 5;

        var seats = new List<Seat>();

        for (int row = 1; row <= rows; row++)
        {
            int posY = (shape.Y + ((row - 1) * spacingY) + shape.Padding) ?? 0;

            for (int col = 1; col <= cols; col++)
            {
                int posX = (shape.X + ((col - 1) * spacingX) + shape.Padding)  ?? 0;

                seats.Add(new Seat
                {
                    SectorId = sector.SectorId,
                    RowNumber = row,
                    ColumnNumber = col,
                    PosX = posX,
                    PosY = posY
                });
            }
        }

        return seats;
    }
}
