using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Response;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Queries
{
    public interface IGetTransactionPaginatedService
    {
        Task<PaginatedDTO<ResponseTransactionItemDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default);
    }
}
