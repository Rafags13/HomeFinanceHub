using HomeFinanceHub.Domain.Entities.Common;

namespace HomeFinanceHub.Domain.Entities.Persons
{
    public class Person : BaseEntity
    {
        public string Name { get; init; } = string.Empty;
        public int Age { get; init; }
    }
}
