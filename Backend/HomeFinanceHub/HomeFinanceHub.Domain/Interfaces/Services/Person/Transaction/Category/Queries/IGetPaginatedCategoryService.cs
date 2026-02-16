using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Response;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries
{
    public interface IGetPaginatedCategoryService
    {
        Task<PaginatedDTO<ResponsePaginatedCategoryDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default);
    }
}
