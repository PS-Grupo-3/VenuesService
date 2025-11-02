using Application.Interfaces.Strategies;

namespace Application.Interfaces.Factories
{
    public interface ISeatGenerationStrategyFactory
    {
        ISeatGenerationStrategy Resolve(string shapeType);
    }
}



