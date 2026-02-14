using HomeFinanceHub.Domain.Interfaces.Repository;
using HomeFinanceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeFinanceHub.Infrastructure.Repository
{
    public class BaseRepository<TEntity>(HomeFinanceHubContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected HomeFinanceHubContext Context { get; } = context;

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return Context.Set<TEntity>().AnyAsync(predicate, ct);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }
    }
}
