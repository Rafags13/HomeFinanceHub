using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeFinanceHub.Infrastructure.Context.Configurations.Persons.Transactions
{
    internal sealed class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(400);

            builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
        }
    }
}
