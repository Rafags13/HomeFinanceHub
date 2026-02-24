using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeFinanceHub.Infrastructure.Context.Configurations.Persons.Transactions
{
    internal sealed class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(400);
        }
    }
}
