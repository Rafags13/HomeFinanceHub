using HomeFinanceHub.Application.Services.Person.Commands;
using HomeFinanceHub.Application.Services.Person.Queries;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HomeFinanceHub.Application.Extensions.Services.Person
{
    internal static class PersonServiceExtensions
    {
        public static IServiceCollection AddPersonServices(this IServiceCollection services)
        {
            services.AddTransient<ICreatePersonService, CreatePersonService>();
            services.AddTransient<IUpdatePersonService, UpdatePersonService>();
            services.AddTransient<IDeletePersonService, DeletePersonService>();
            services.AddTransient<IGetPaginatedPersonService, GetPaginatedPersonService>();

            return services;
        }
    }
}
