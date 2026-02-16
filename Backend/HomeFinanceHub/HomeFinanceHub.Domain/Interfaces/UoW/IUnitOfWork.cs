using HomeFinanceHub.Domain.Interfaces.Repository.Persons;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeFinanceHub.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IPersonRepository PersonRepository { get; }

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct);
        Task<int> CommitAsync(CancellationToken ct);
    }
}
