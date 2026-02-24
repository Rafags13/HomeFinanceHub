using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.DTOs.Person.Response
{
    public record ResponsePaginatedPersonDTO(
        IEnumerable<PaginatedPersonItemDTO> Items,
        int Page,
        sbyte PageSize,
        int TotalItems,
        IEnumerable<KeyValuePair<EExpenseCategoryType, decimal>> TotalExpensesByType,
        decimal TotalBalance
        ) :
        PaginatedDTO<PaginatedPersonItemDTO>(Items, Page, PageSize, TotalItems);
}
