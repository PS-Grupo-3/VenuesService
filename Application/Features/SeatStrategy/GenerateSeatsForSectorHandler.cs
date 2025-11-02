using Application.Interfaces.Command;
using Application.Interfaces.Factories;
using Application.Interfaces.Query;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.SeatStrategy;

public class GenerateSeatsForSectorHandler : IRequestHandler<GenerateSeatsForSectorCommand, GenerateSeatsResultResponse>
{
    private readonly ISectorQuery _sectorQuery;
    private readonly ISeatCommand _seatCommand;
    private readonly ISeatGenerationStrategyFactory _factory;

    public GenerateSeatsForSectorHandler(ISectorQuery sectorQuery, ISeatCommand seatCommand, ISeatGenerationStrategyFactory factory)
    {
        _sectorQuery = sectorQuery;
        _seatCommand = seatCommand;
        _factory = factory;
    }
    
    public async Task<GenerateSeatsResultResponse> Handle(GenerateSeatsForSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = await _sectorQuery.GetByIdAsync(request.SectorId, cancellationToken)
                     ?? throw new KeyNotFoundException("Sector no encontrado");

        if (!sector.IsControlled)
            throw new InvalidOperationException("El sector no permite asientos individuales");

        var strategy = _factory.Resolve(sector.Shape.Type);
        var seats = strategy.GenerateSeats(sector);

        foreach (var seat in seats)
            await _seatCommand.InsertAsync(seat, cancellationToken);

        return new GenerateSeatsResultResponse
        {
            SectorId = sector.SectorId,
            SectorName = sector.Name,
            ShapeType = sector.Shape.Type,
            SeatsGenerated = seats.Count(),
            GeneratedAt = DateTime.UtcNow
        };
    }
}

