namespace HomeFinanceHub.Domain.Interfaces.Services.Person.Queries
{
    public interface ISearchPersonService
    {
        Task<KeyValuePair<long, string>[]> SearchAsync(string? name, CancellationToken cancellationToken = default);
    }
}
