using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Entities.Persons;

namespace HomeFinanceHub.Domain.Interfaces.Repository.Persons
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<bool> CreateAsync(RequestCreatePersonDTO content, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(RequestUpdatePersonDTO content, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
        Task<ResponsePaginatedPersonDTO> PaginateAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default);
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<int?> GetAgeAsync(long id, CancellationToken cancellationToken = default);
        Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default);
    }
}
