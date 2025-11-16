using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;
public class CircleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        var shape = sector.Shape;

        if (shape.Rows is null || shape.Columns is null)
            throw new InvalidOperationException("Circle requiere Rows y Columns.");

        int rings = shape.Rows.Value;
        int seatsPerRing = shape.Columns.Value;

        int cx = shape.X ?? 0;
        int cy = shape.Y ?? 0;
        int padding = shape.Padding ?? 0;

        var result = new List<Seat>();

        for (int r = 1; r <= rings; r++)
        {
            int radius = padding + r * 12;
            double step = 360.0 / seatsPerRing;

            for (int s = 0; s < seatsPerRing; s++)
            {
                double angle = s * step * Math.PI / 180.0;

                int posX = cx + (int)(Math.Cos(angle) * radius);
                int posY = cy + (int)(Math.Sin(angle) * radius);

                result.Add(new Seat
                {
                    SectorId = sector.SectorId,
                    RowNumber = r,
                    ColumnNumber = s + 1,
                    PosX = posX,
                    PosY = posY
                });
            }
        }

        return result;
    }
}
