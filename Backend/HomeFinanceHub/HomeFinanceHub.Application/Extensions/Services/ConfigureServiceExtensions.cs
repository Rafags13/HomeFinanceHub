using HomeFinanceHub.Application.Extensions.Services.Person;
using HomeFinanceHub.Application.Extensions.Services.Person.Transaction;
using HomeFinanceHub.Application.Extensions.Services.Person.Transaction.Category;
using Microsoft.Extensions.DependencyInjection;

namespace HomeFinanceHub.Application.Extensions.Services
{
    public static class ConfigureServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddPersonServices()
                .AddCategoryServices()
                .AddTransactionServices();
        }
    }
}
