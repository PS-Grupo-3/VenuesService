using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;
public class ArcSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        var shape = sector.Shape;

        if (shape.Rows is null || shape.Columns is null)
            throw new InvalidOperationException("Arc requiere Rows y Columns.");

        int rings = shape.Rows.Value;
        int seatsPerRing = shape.Columns.Value;

        int cx = shape.X ?? 0;
        int cy = shape.Y ?? 0;
        int padding = shape.Padding ?? 0;

        int baseRadius = 20;
        int ringSpacing = 12;

        double start = 150.0;
        double end = 30.0;

        double span = start - end;

        var result = new List<Seat>();

        for (int r = 1; r <= rings; r++)
        {
            int radius = baseRadius + ((r - 1) * ringSpacing) + padding;
            double angleStep = span / (seatsPerRing - 1);

            for (int s = 0; s < seatsPerRing; s++)
            {
                double angleDeg = start - s * angleStep;
                double angleRad = Math.PI * angleDeg / 180.0;

                int posX = cx + (int)(Math.Cos(angleRad) * radius);
                int posY = cy + (int)(Math.Sin(angleRad) * radius);

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
