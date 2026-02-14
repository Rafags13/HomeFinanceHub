using HomeFinanceHub.Domain.Interfaces.UoW;
using HomeFinanceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeFinanceHub.Infrastructure.UoW
{
    internal class UnitOfWork(HomeFinanceHubContext context) : IUnitOfWork
    {
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
