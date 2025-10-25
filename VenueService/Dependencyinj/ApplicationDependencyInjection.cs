using MediatR;
using Application.Features.Seat.Handlers;

namespace VenueService.Dependencyinj
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registra todos los handlers del ensamblado donde está UpdateSeatHandler
            services.AddMediatR(typeof(UpdateSeatHandler).Assembly);

            return services;
        }
    }
}
