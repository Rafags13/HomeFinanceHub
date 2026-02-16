using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Queries
{
    internal sealed class GetPaginatedPersonService(
        IUnitOfWork unitOfWork
    ) : IGetPaginatedPersonService
    {
        public Task<PaginatedDTO<ResponsePaginatedPersonDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default)
        {
            return unitOfWork.PersonRepository.PaginateAsync(page, pageSize, cancellationToken);
        }
    }
}
