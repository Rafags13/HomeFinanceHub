using HomeFinanceHub.Domain.Interfaces.Repository.Persons;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions.Categories;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeFinanceHub.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IPersonRepository PersonRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITransactionRepository TransactionRepository { get; }

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct);
        Task<int> CommitAsync(CancellationToken ct);
    }
}
