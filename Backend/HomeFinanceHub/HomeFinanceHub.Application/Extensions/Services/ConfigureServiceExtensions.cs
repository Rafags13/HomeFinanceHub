using Microsoft.Extensions.DependencyInjection;

namespace HomeFinanceHub.Application.Extensions.Services
{
    public static class ConfigureServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddPersonServices();
        }
    }
}
