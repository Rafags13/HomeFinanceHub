using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request;
using HomeFinanceHub.Domain.Errors;
using OneOf;

namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Commands
{
    public interface ICreateCategoryService
    {
        Task<OneOf<bool, BaseError>> CreateAsync(RequestCreateCategoryDTO content, CancellationToken cancellationToken = default);
    }
}
