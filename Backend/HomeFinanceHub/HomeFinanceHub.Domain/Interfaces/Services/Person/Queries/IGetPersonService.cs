using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Errors;
using OneOf;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Queries
{
    public interface IGetPersonService
    {
        Task<OneOf<PersonDTO, BaseError>> GetAsync(long id, CancellationToken cancellationToken = default);
    }
}
