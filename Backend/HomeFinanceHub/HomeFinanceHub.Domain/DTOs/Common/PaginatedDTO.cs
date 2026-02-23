namespace HomeFinanceHub.Domain.DTOs.Common
{
    public record PaginatedDTO<T>(IEnumerable<T> Items, int Page, sbyte PageSize, int TotalItems);
}
