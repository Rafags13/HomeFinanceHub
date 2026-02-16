using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.Errors;
using OneOf;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Commands
{
    public interface ICreatePersonService
    {
        Task<OneOf<bool, BaseError>> CreateAsync(RequestCreatePersonDTO content, CancellationToken cancellationToken = default);
    }
}
