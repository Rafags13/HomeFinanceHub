using HomeFinanceHub.Domain.Interfaces.Repository;
using HomeFinanceHub.Domain.Interfaces.UoW;
using HomeFinanceHub.Infrastructure.Context;
using HomeFinanceHub.Infrastructure.Repository;
using HomeFinanceHub.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomeFinanceHub.Infrastructure.Extensions
{
    public static class ConfigureInfrastructureExtensions
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services.ConfigureRepository(configuration);
        }

        private static IServiceCollection ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = Environment.GetEnvironmentVariable("CONTEXT_DATA_SOURCE");

            services.AddDbContext<HomeFinanceHubContext>(options =>
            {
                if (!string.IsNullOrEmpty(connectionString))
                    options.UseNpgsql(connectionString);
                else
                    options.UseNpgsql(configuration.GetConnectionString("CONTEXT_DATA_SOURCE"));

                options.LogTo(Console.WriteLine, LogLevel.Information);
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
