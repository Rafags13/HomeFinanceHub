using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.DTOs.Person.Transaction.Request
{
    public record RequestCreateTransactionDTO(string? Description, decimal Value, EExpenseCategoryType Type, long CategoryId, long PersonId);
}
