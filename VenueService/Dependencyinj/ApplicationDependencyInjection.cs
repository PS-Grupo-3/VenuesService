using Application.Factories;
using MediatR;
using Application.Features.Seat.Handlers;
using Application.Features.SeatStrategy;
using Application.Interfaces.Factories;
using Application.Interfaces.Strategies;
using Application.Strategies;

namespace VenueService.Dependencyinj
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GenerateSeatsForSectorCommand).Assembly);

            services.AddScoped<RectangleSeatGenerationStrategy>();
            services.AddScoped<CircleSeatGenerationStrategy>();
            services.AddScoped<SemiCircleSeatGenerationStrategy>();
            services.AddScoped<ArcSeatGenerationStrategy>();

            services.AddScoped<ISeatGenerationStrategyFactory, SeatGenerationStrategyFactory>();

            return services;
        }

    }
}
