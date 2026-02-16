using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Response;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Queries
{
    public interface IGetPaginatedPersonService
    {
        Task<PaginatedDTO<ResponsePaginatedPersonDTO>> GetPaginatedAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default);
    }
}
