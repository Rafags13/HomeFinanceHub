using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.Entities.Common;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using HomeFinanceHub.Infrastructure.Extensions;

namespace HomeFinanceHub.Domain.Entities.Persons
{
    public class Person : BaseDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string NormalizedName { get; private set; } = string.Empty;
        public int Age { get; init; }

        protected Person() { }

        public Person(RequestCreatePersonDTO content)
        {
            Name = content.Name;
            NormalizedName = content.Name.StringNormalization();
            Age = content.Age;
        }

        public void Update(RequestUpdatePersonDTO content)
        {
            Name = content.Name;
        }

        #region [Navigations]
        public ICollection<Transaction> Transactions { get; private set; } = [];
        #endregion
    }
}
