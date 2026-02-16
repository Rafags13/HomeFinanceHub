using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request
{
    public record RequestCreateCategoryDTO(string Description, EExpenseCategoryType PurposeType);
}
