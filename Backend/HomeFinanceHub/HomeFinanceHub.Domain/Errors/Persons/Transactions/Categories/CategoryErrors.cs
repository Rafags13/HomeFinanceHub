using Microsoft.AspNetCore.Http;

namespace HomeFinanceHub.Domain.Errors.Persons.Transactions.Categories
{
    public record CategoryNotFoundError()
        : BaseError("A categoria buscada não existe.", nameof(CategoryNotFoundError), StatusCodes.Status404NotFound);

    public record CategoryDescriptionMaxLengthError(int Size)
        : BaseError($"A descrição da categoria pode ter {Size} caracteres no máximo.", nameof(CategoryDescriptionMaxLengthError), StatusCodes.Status400BadRequest);
}
