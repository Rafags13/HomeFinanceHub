using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.DTOs.Person.Response
{
    public record PaginatedPersonItemDTO(
        long Id,
        string Name,
        int Age,
        IEnumerable<KeyValuePair<EExpenseCategoryType, decimal>> TotalExpensesByType,
        decimal Balance);
}
