using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Queries
{
    internal sealed class GetPaginatedPersonService(
        IUnitOfWork unitOfWork
    ) : IGetPaginatedPersonService
    {
        /// <summary>
        /// Serviço responsável por retornar a listagem paginada das pessoas do sistema,
        /// permitindo que o cliente especifique a página e o número de itens por página.
        /// </summary>
        public Task<ResponsePaginatedPersonDTO> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            return unitOfWork.PersonRepository.PaginateAsync(page, pageSize, cancellationToken);
        }
    }
}
