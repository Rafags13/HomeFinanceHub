using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Transaction.Category.Queries
{
    internal sealed class SearchCategoryService(
        IUnitOfWork unitOfWork
    ) : ISearchCategoryService
    {
        /// <summary>
        /// Serviço responsável por buscar uma categoria em específico por seu nome.
        /// Esse serviço é utilizado principalmente para o cadastro de transações,
        /// onde é necessário selecionar uma categoria para associar a transação.
        /// </summary>
        public Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default)
        {
            return unitOfWork.CategoryRepository.SearchAsync(name, cancellationToken);
        }
    }
}
