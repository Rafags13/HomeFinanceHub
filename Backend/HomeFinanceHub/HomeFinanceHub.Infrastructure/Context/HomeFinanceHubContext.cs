using HomeFinanceHub.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace HomeFinanceHub.Infrastructure.Context
{
    public class HomeFinanceHubContext(DbContextOptions<HomeFinanceHubContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State is EntityState.Added or EntityState.Modified))
            {
                if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                else if (entry.State == EntityState.Added)
                    entry.Entity.CreatedAt ??= DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
