using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions;
using HomeFinanceHub.Infrastructure.Context;

namespace HomeFinanceHub.Infrastructure.Repository.Persons.Transactions
{
    internal sealed class TransactionRepository(HomeFinanceHubContext context) : BaseRepository<Transaction>(context), ITransactionRepository
    {
        public async Task<bool> CreateAsync(RequestCreateTransactionDTO content, CancellationToken cancellationToken = default)
        {
            var transaction = new Transaction(content);

            await Context.Transaction.AddAsync(transaction, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
