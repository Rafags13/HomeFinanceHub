using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Entities.Persons;
using HomeFinanceHub.Domain.Enums.Transaction;
using HomeFinanceHub.Domain.Extensions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons;
using HomeFinanceHub.Infrastructure.Context;
using HomeFinanceHub.Infrastructure.Extensions;
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

        public async Task<ResponsePaginatedPersonDTO> PaginateAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            var query = GetAll();

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .Paginate(page, pageSize)
                .Select(x => new PaginatedPersonItemDTO(
                    x.Id,
                    x.Name,
                    x.Age,
                    x.Transactions
                        .GroupBy(y => y.Type)
                        .Select(y => new KeyValuePair<EExpenseCategoryType, decimal>(y.Key, y.Sum(z => z.Value))),
                    x.Transactions
                        .Sum(y => y.Type == EExpenseCategoryType.Expenditure ? (y.Value * -1) : y.Value)))
                .ToArrayAsync(cancellationToken);

            var expensesGroupedByType = await Context.Transaction
                .GroupBy(x => x.Type, (transaction) => new
                {
                    transaction.Type,
                    transaction.Value
                })
                .Select(x => new KeyValuePair<EExpenseCategoryType, decimal>(x.Key, x.Sum(z => z.Type == EExpenseCategoryType.Expenditure ? (z.Value * -1) : z.Value)))
                .ToArrayAsync(cancellationToken);

            return new ResponsePaginatedPersonDTO(items, page, pageSize, totalItems, expensesGroupedByType, expensesGroupedByType.Sum(x => x.Value));
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

        public Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.NormalizedName.Contains(name.StringNormalization()));

            return query
                .Select(x => new KeyValuePair<long, string>(x.Id, x.Name))
                .ToArrayAsync(cancellationToken);
        }
    }
}
