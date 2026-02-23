using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.DTOs.Person.Transaction.Response
{
    public record ResponseTransactionItemDTO(
        string? Description,
        decimal Value,
        EExpenseCategoryType Type,
        string CategoryDescription,
        string PersonName
    );
}
