using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Response;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Transaction.Queries
{
    internal sealed class GetTransactionPaginatedService(
        IUnitOfWork unitOfWork
    ) : IGetTransactionPaginatedService
    {
        public Task<PaginatedDTO<ResponseTransactionItemDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            return unitOfWork.TransactionRepository.GetPaginatedAsync(page, pageSize, cancellationToken);
        }
    }
}
