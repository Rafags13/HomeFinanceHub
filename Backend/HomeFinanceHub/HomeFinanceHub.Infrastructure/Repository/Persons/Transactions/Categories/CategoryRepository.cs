using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Response;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using HomeFinanceHub.Domain.Enums.Transaction;
using HomeFinanceHub.Domain.Extensions;
using HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions.Categories;
using HomeFinanceHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeFinanceHub.Infrastructure.Repository.Persons.Transactions.Categories
{
    internal sealed class CategoryRepository(HomeFinanceHubContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        public async Task<bool> CreateAsync(RequestCreateCategoryDTO content, CancellationToken cancellationToken = default)
        {
            var category = new Category(content);

            await Context.Category.AddAsync(category, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }

        public Task<EExpenseCategoryType?> GetPurposeTypeAsync(long id, CancellationToken cancellationToken = default)
        {
            return GetAll(x => x.Id == id)
                .Select(x => (EExpenseCategoryType?)x.PurposeType)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginatedDTO<ResponsePaginatedCategoryDTO>> PaginateAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            var query = GetAll();

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query.Paginate(page, pageSize)
                .Select(x => new ResponsePaginatedCategoryDTO(x.Description, x.PurposeType))
                .ToArrayAsync(cancellationToken);

            return new PaginatedDTO<ResponsePaginatedCategoryDTO>(items, page, pageSize, totalItems);
        }
    }
}
