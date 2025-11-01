using Application.Interfaces; 
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace VenueService.Dependencyinj
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IVenueCommand, VenueCommand>();
            services.AddScoped<ISectorCommand, SectorCommand>();
            services.AddScoped<ISeatCommand, SeatCommand>();
            services.AddScoped<IShapeCommand, ShapeCommand>();

            services.AddScoped<ISeatQuery, SeatQuery>();
            services.AddScoped<ISectorQuery, SectorQuery>();
            services.AddScoped<IVenueQuery, VenueQuery>();
            services.AddScoped<IVenueTypeQuery, VenueTypeQuery>();
            services.AddScoped<IShapeQuery, ShapeQuery>();


            return services;
        }
    }
}