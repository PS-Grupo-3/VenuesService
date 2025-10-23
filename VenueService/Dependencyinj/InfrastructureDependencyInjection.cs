using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;


namespace VenueService.Dependencyinj
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Commands & Queries
            services.AddScoped<IVenueCommand, VenueCommand>();
            services.AddScoped<ISectorCommand, SectorCommand>();
            services.AddScoped<ISeatCommand, SeatCommand>();
            services.AddScoped<ISeatQuery, SeatQuery>();
            services.AddScoped<ISectorQuery, SectorQuery>();
            services.AddScoped<IVenueQuery, VenueQuery>();
            services.AddScoped<IVenueTypeQuery, VenueTypeQuery>();

            return services;
        }
    }
}