using HomeFinanceHub.Domain.Entities.Common;
using HomeFinanceHub.Domain.Entities.Persons;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using Microsoft.EntityFrameworkCore;

namespace HomeFinanceHub.Infrastructure.Context
{
    public class HomeFinanceHubContext(DbContextOptions<HomeFinanceHubContext> options) : DbContext(options)
    {
        public DbSet<Person> Person { get; private set; }
        public DbSet<Category> Category { get; private set; }
        public DbSet<Transaction> Transaction { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomeFinanceHubContext).Assembly);

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
