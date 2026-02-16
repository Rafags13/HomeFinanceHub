using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.Entities.Common;
using HomeFinanceHub.Infrastructure.Extensions;

namespace HomeFinanceHub.Domain.Entities.Persons
{
    public class Person : BaseDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string NormalizedName { get; private set; } = string.Empty;
        public int Age { get; init; }

        protected Person() { }

        public Person(CreatePersonDTO content)
        {
            Name = content.Name;
            NormalizedName = content.Name.StringNormalization();
            Age = content.Age;
        }

        public void Update(UpdatePersonDTO content)
        {
            Name = content.Name;
        }
    }
}
