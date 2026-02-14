using HomeFinanceHub.Domain.Entities.Persons;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons;
using HomeFinanceHub.Infrastructure.Context;

namespace HomeFinanceHub.Infrastructure.Repository.Persons
{
    internal sealed class PersonRepository(HomeFinanceHubContext context) : BaseRepository<Person>(context), IPersonRepository
    {
    }
}
