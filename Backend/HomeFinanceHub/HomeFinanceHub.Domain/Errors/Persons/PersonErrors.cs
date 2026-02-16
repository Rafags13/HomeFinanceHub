using Microsoft.AspNetCore.Http;

namespace HomeFinanceHub.Domain.Errors.Persons
{
    public record PersonNotFoundError()
        : BaseError("A pessoa informada não existe.", nameof(PersonNotFoundError), StatusCodes.Status404NotFound);

    public record PersonNameMaxLengthError(byte Size)
        : BaseError($"O nome da pessoa deve ter no máximo {Size} caracteres.", nameof(PersonNameMaxLengthError), StatusCodes.Status400BadRequest);
}
