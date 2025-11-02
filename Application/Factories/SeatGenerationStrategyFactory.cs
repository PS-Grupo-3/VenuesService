using Application.Interfaces.Factories;
using Application.Interfaces.Strategies;
using Application.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories;

public class SeatGenerationStrategyFactory : ISeatGenerationStrategyFactory
{
    private readonly Dictionary<string, ISeatGenerationStrategy> _strategies;

    public SeatGenerationStrategyFactory(IServiceProvider provider)
    {
        _strategies = new(StringComparer.OrdinalIgnoreCase)
        {
            { "rectangle", provider.GetRequiredService<RectangleSeatGenerationStrategy>() },
            { "circle", provider.GetRequiredService<CircleSeatGenerationStrategy>() },
            { "semicircle", provider.GetRequiredService<SemiCircleSeatGenerationStrategy>() },
            { "arc", provider.GetRequiredService<ArcSeatGenerationStrategy>() }
        };
    }

    public ISeatGenerationStrategy Resolve(string shapeType)
    {
        if (_strategies.TryGetValue(shapeType, out var strategy))
            return strategy;

        throw new NotSupportedException($"Shape del tipo: '{shapeType}' no soportada.");
    }
}




