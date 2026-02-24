using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Queries
{
    internal sealed class SearchPersonService(
        IUnitOfWork unitOfWork
    ) : ISearchPersonService
    {
        /// <summary>
        /// Serviço responsável por buscar uma pessoa em específico por seu nome.
        /// Esse serviço é utilizado principalmente para o cadastro de transações,
        /// onde é necessário selecionar uma pessoa para associar a transação.
        /// </summary>

        public Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default)
        {
            return unitOfWork.PersonRepository.SearchAsync(name, cancellationToken);
        }
    }
}
