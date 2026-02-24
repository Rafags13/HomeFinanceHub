using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Response;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Transaction.Category.Queries
{
    internal sealed class GetPaginatedCategoryService(
        IUnitOfWork unitOfWork
    ) : IGetPaginatedCategoryService
    {
        /// <summary>
        /// Serviço responsável por retornar a listagem paginada de categorias,
        /// sendo possível selecionar a pagina, bem como seu tamanho.
        /// </summary>

        public Task<PaginatedDTO<ResponsePaginatedCategoryDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            return unitOfWork.CategoryRepository.PaginateAsync(page, pageSize, cancellationToken);
        }
    }
}
