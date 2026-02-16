using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Errors.Persons;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Commands;
using HomeFinanceHub.Domain.Interfaces.UoW;
using OneOf;

namespace HomeFinanceHub.Application.Services.Person.Commands
{
    internal sealed class DeletePersonService(
        IUnitOfWork unitOfWork
    ) : IDeletePersonService
    {
        public async Task<OneOf<bool, BaseError>> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var error = await ValidateAsync(id, cancellationToken);
            if (error != null) return error;

            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);

            if (await unitOfWork.TransactionRepository.AnyAsync(x => x.PersonId == id, cancellationToken) &&
                await unitOfWork.TransactionRepository.DeleteRangeAsync(id, cancellationToken) == 0)
                return new DatabaseError();

            if (!await unitOfWork.PersonRepository.DeleteAsync(id, cancellationToken))
                return new DatabaseError();

            await transaction.CommitAsync(cancellationToken);

            return true;
        }

        private async Task<BaseError?> ValidateAsync(long id, CancellationToken cancellationToken = default)
        {
            if (!await unitOfWork.PersonRepository.AnyAsync(x => x.Id == id, cancellationToken))
                return new PersonNotFoundError();

            return null;
        }
    }
}
