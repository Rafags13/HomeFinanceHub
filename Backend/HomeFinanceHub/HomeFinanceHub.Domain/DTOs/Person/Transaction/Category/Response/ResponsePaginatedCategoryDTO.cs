using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Response
{
    public record ResponsePaginatedCategoryDTO(string Description, EExpenseCategoryType PurposeType);
}
