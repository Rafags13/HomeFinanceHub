using HomeFinanceHub.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeFinanceHub.Infrastructure.Context.Configurations.Persons
{
    internal sealed class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(200);

            builder.Property(x => x.NormalizedName)
                .HasMaxLength(200);

            builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
        }
    }
}
