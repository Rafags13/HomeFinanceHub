using HomeFinanceHub.Application.Services.Person.Transaction.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace HomeFinanceHub.Application.Extensions.Services.Person.Transaction
{
    internal static class TransactionServiceExtensions
    {
        internal static IServiceCollection AddTransactionServices(this IServiceCollection services)
        {
            services.AddTransient<ICreateTransactionService, CreateTransactionService>();

            return services;
        }
    }
}
