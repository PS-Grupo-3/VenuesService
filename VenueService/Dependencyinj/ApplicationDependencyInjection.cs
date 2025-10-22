using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Seat.Commands;

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
