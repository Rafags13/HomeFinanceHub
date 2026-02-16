using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.Errors;
using OneOf;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Commands
{
    public interface ICreateTransactionService
    {
        Task<OneOf<bool, BaseError>> CreateAsync(RequestCreateTransactionDTO content, CancellationToken cancellationToken = default);
    }
}
