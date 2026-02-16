using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Entities.Persons;
using HomeFinanceHub.Domain.Extensions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons;
using HomeFinanceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeFinanceHub.Infrastructure.Repository.Persons
{
    internal sealed class PersonRepository(HomeFinanceHubContext context) : BaseRepository<Person>(context), IPersonRepository
    {
        public async Task<bool> CreateAsync(RequestCreatePersonDTO content, CancellationToken cancellationToken = default)
        {
            var person = new Person(content);

            await Context.Person.AddAsync(person, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateAsync(RequestUpdatePersonDTO content, CancellationToken cancellationToken = default)
        {
            var person = await GetByIdAsync(content.Id, cancellationToken);

            if (person is null) return false;

            person.Update(content);

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var person = await GetByIdAsync(id, cancellationToken);

            if (person is null) return false;

            person.Delete();

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }

        private async Task<Person?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await Context.Person.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<PaginatedDTO<ResponsePaginatedPersonDTO>> PaginateAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            var query = GetAll();

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .Paginate(page, pageSize)
                .Select(x => new ResponsePaginatedPersonDTO(x.Id, x.Name, x.Age))
                .ToArrayAsync(cancellationToken);

            return new PaginatedDTO<ResponsePaginatedPersonDTO>(items, page, pageSize, totalItems);
        }

        public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return AnyAsync(x => x.Name == name, cancellationToken);
        }

        public Task<int?> GetAgeAsync(long id, CancellationToken cancellationToken = default)
        {
            return GetAll(x => x.Id == id)
                .Select(x => (int?)x.Age)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
