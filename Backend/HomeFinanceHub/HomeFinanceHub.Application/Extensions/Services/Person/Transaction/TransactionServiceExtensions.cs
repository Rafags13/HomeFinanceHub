using HomeFinanceHub.Application.Services.Person.Transaction.Commands;
using HomeFinanceHub.Application.Services.Person.Transaction.Queries;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HomeFinanceHub.Application.Extensions.Services.Person.Transaction
{
    internal static class TransactionServiceExtensions
    {
        internal static IServiceCollection AddTransactionServices(this IServiceCollection services)
        {
            services.AddTransient<ICreateTransactionService, CreateTransactionService>();
            services.AddTransient<IGetTransactionPaginatedService, GetTransactionPaginatedService>();

            return services;
        }
    }
}
