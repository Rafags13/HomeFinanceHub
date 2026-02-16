namespace HomeFinanceHub.Domain.DTOs.Comon
{
    public record PaginatedDTO<T>(IEnumerable<T> Items, int Page, sbyte PageSize, int TotalItems);
}
