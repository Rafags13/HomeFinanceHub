namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries
{
    public interface ISearchCategoryService
    {
        Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default);
    }
}
