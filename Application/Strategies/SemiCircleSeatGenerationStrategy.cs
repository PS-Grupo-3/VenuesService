using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class SemiCircleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        if (sector.RowNumber is null)
            throw new InvalidOperationException("SemiCircle requiere RowNumber como número de anillos");

        int rings = sector.RowNumber.Value;
        int seatsPerRing = sector.ColumnNumber ?? 10;

        var result = new List<Seat>();

        int centerX = sector.PosX ?? 0;
        int centerY = sector.PosY ?? 0;
        int padding = sector.Shape.Padding;

        int baseRadius = 20;
        int ringSpacing = 12;

        for (int r = 1; r <= rings; r++)
        {
            int radius = baseRadius + ((r - 1) * ringSpacing) + padding;
            double angleStep = 180.0 / (seatsPerRing - 1); // -1 so edges touch boundary

            for (int s = 0; s < seatsPerRing; s++)
            {
                double angleDeg = 180.0 - (s * angleStep); // empieza en 180° (izq) → 0° (der)
                double angleRad = Math.PI * angleDeg / 180.0;

                int posX = centerX + (int)(Math.Cos(angleRad) * radius);
                int posY = centerY + (int)(Math.Sin(angleRad) * radius);

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