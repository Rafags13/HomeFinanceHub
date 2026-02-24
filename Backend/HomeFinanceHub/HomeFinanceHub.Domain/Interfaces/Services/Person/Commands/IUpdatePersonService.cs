using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.Errors;
using OneOf;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Commands
{
    public interface IUpdatePersonService
    {
        Task<OneOf<bool, BaseError>> UpdateAsync(RequestUpdatePersonDTO content, CancellationToken cancellationToken = default);
    }
}
