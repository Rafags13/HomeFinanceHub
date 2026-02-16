using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Response;
using HomeFinanceHub.Domain.Entities.Persons.Transactions;
using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.Interfaces.Repository.Persons.Transactions.Categories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> CreateAsync(RequestCreateCategoryDTO content, CancellationToken cancellationToken = default);
        Task<PaginatedDTO<ResponsePaginatedCategoryDTO>> PaginateAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default);
        Task<EExpenseCategoryType?> GetPurposeTypeAsync(long id, CancellationToken cancellationToken = default);
    }
}
