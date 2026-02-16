using HomeFinanceHub.Application.Services.Person.Transaction.Category.Commands;
using HomeFinanceHub.Application.Services.Person.Transaction.Category.Queries;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HomeFinanceHub.Application.Extensions.Services.Person.Transaction.Category
{
    internal static class CategoryServiceExtensions
    {
        internal static IServiceCollection AddCategoryServices(this IServiceCollection services)
        {
            services.AddTransient<ICreateCategoryService, CreateCategoryService>();
            services.AddTransient<IGetPaginatedCategoryService, GetPaginatedCategoryService>();

            return services;
        }
    }
}
