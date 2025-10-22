using System.Reflection;

namespace VenueService.Dependencyinj
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.Load("Application"))
            );

            return services;
        }
    }
}