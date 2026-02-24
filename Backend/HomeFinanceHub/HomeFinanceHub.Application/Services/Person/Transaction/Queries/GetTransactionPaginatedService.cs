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
        /// <summary>
        /// Serviço responsável por retornar a listagem paginada de transações,
        /// sendo possível selecionar a pagina, bem como seu tamanho.
        /// </summary>
        public Task<PaginatedDTO<ResponseTransactionItemDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            return unitOfWork.TransactionRepository.GetPaginatedAsync(page, pageSize, cancellationToken);
        }
    }
}
