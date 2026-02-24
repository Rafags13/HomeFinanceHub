using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Response;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using HomeFinanceHub.Domain.Extensions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions;
using HomeFinanceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace HomeFinanceHub.Infrastructure.Repository.Persons.Transactions
{
    internal sealed class TransactionRepository(HomeFinanceHubContext context) : BaseRepository<Transaction>(context), ITransactionRepository
    {
        public async Task<bool> CreateAsync(RequestCreateTransactionDTO content, CancellationToken cancellationToken = default)
        {
            var transaction = new Transaction(content);

            await Context.Transaction.AddAsync(transaction, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }

        public Task<int> DeleteRangeAsync(long personId, CancellationToken cancellationToken = default)
        {
            return GetAll(x => x.PersonId == personId)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(y => y.DeletedAt, DateTime.UtcNow), cancellationToken);
        }

        public async Task<PaginatedDTO<ResponseTransactionItemDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            var query = GetAll();

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .Paginate(page, pageSize)
                .Select(x => new ResponseTransactionItemDTO(
                    x.Description,
                    x.Value,
                    x.Type,
                    x.Category.Description,
                    x.Person.Name))
                .ToArrayAsync(cancellationToken);

            return new PaginatedDTO<ResponseTransactionItemDTO>(items, page, pageSize, totalItems);
        }
    }
}
