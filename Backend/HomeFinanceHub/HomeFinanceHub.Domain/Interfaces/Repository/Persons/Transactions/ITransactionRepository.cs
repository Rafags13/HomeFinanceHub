using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;

namespace HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<bool> CreateAsync(RequestCreateTransactionDTO content, CancellationToken cancellationToken = default);
        Task<int> DeleteRangeAsync(long personId, CancellationToken cancellationToken = default);
    }
}
