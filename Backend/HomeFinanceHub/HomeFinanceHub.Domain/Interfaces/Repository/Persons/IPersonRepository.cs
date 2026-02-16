using HomeFinanceHub.Domain.DTOs.Comon;
using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Entities.Persons;

namespace HomeFinanceHub.Domain.Interfaces.Repository.Persons
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<bool> CreateAsync(CreatePersonDTO content, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(UpdatePersonDTO content, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
        Task<PaginatedDTO<PaginatedPersonDTO>> PaginateAsync(int page, sbyte pageSize, CancellationToken cancellationToken = default);
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
