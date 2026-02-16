using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Transaction.Category.Queries
{
    internal sealed class SearchCategoryService(
        IUnitOfWork unitOfWork
    ) : ISearchCategoryService
    {
        public Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default)
        {
            return unitOfWork.CategoryRepository.SearchAsync(name, cancellationToken);
        }
    }
}
