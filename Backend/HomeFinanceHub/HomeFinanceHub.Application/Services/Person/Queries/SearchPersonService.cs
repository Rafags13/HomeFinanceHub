using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;

namespace HomeFinanceHub.Application.Services.Person.Queries
{
    internal sealed class SearchPersonService(
        IUnitOfWork unitOfWork
    ) : ISearchPersonService
    {
        public Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default)
        {
            return unitOfWork.PersonRepository.SearchAsync(name, cancellationToken);
        }
    }
}
