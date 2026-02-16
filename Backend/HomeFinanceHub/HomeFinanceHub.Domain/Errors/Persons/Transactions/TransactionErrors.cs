using Microsoft.AspNetCore.Http;

namespace HomeFinanceHub.Domain.Errors.Persons.Transactions
{
    public record TransactionCategoryTypeError()
        : BaseError("O tipo da transação deve ser compatível com a finalidade da categoria.", nameof(TransactionCategoryTypeError), StatusCodes.Status409Conflict);

    public record TransactionRevenueAgeError(int MinAge)
        : BaseError($"Apenas transações do tipo \"Despesa\" são aceitas quando a pessoa tem mais de {MinAge} anos.", nameof(TransactionRevenueAgeError), StatusCodes.Status409Conflict);
}
