using HomeFinanceHub.Domain.Errors;
using OneOf;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Commands
{
    public interface IDeletePersonService
    {
        Task<OneOf<bool, BaseError>> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
