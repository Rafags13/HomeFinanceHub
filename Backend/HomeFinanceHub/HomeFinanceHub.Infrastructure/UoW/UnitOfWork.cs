using HomeFinanceHub.Domain.Interfaces.Repository.Persons;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions.Categories;
using HomeFinanceHub.Domain.Interfaces.UoW;
using HomeFinanceHub.Infrastructure.Context;
using HomeFinanceHub.Infrastructure.Repository.Persons;
using HomeFinanceHub.Infrastructure.Repository.Persons.Transactions;
using HomeFinanceHub.Infrastructure.Repository.Persons.Transactions.Categories;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeFinanceHub.Infrastructure.UoW
{
    internal class UnitOfWork(HomeFinanceHubContext context) : IUnitOfWork
    {
        #region [Person]
        public IPersonRepository PersonRepository { get; private set; } = new PersonRepository(context);
        #endregion

        #region [Transaction]
        public ICategoryRepository CategoryRepository { get; private set; } = new CategoryRepository(context);
        public ITransactionRepository TransactionRepository { get; private set; } = new TransactionRepository(context);
        #endregion

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct)
        {
            return context.Database.BeginTransactionAsync(ct);
        }

        public Task<int> CommitAsync(CancellationToken ct)
        {
            return context.SaveChangesAsync(ct);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            await context.DisposeAsync();
        }
    }
}
