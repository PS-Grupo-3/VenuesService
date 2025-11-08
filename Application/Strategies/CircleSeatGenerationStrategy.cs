using Application.Interfaces.Strategies;
using Domain.Entities;

namespace Application.Strategies;

public class CircleSeatGenerationStrategy : ISeatGenerationStrategy
{
    public IEnumerable<Seat> GenerateSeats(Sector sector)
    {
        if (sector.RowNumber is null)
            throw new InvalidOperationException("Circle requiere RowNumber como número de anillos");

        int rings = sector.RowNumber.Value;      // cantidad de filas circulares
        int seatsPerRing = sector.ColumnNumber ?? 12; // fallback 

        var result = new List<Seat>();

        int centerX = sector.PosX ?? 0;
        int centerY = sector.PosY ?? 0;
        int padding = sector.Shape.Padding;

        int baseRadius = 20;    // distancia mínima del anillo al centro
        int ringSpacing = 12;   // separación entre radios sucesivos

        int seatId = 0;

        for (int r = 1; r <= rings; r++)
        {
            int radius = baseRadius + ((r - 1) * ringSpacing) + padding;
            double angleStep = 360.0 / seatsPerRing;

            for (int s = 0; s < seatsPerRing; s++)
            {
                double angleDeg = s * angleStep;
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