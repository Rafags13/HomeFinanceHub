namespace HomeFinanceHub.Domain.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, sbyte pageSize) where T : class
        {
            return source.Skip(page * pageSize).Take(pageSize);
        }
    }
}
