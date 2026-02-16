using HomeFinanceHub.Domain.Constants.Person;
using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Errors.Persons;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Commands;
using HomeFinanceHub.Domain.Interfaces.UoW;
using OneOf;

namespace HomeFinanceHub.Application.Services.Person.Commands
{
    internal sealed class UpdatePersonService(
        IUnitOfWork unitOfWork
    ) : IUpdatePersonService
    {
        public async Task<OneOf<bool, BaseError>> UpdateAsync(RequestUpdatePersonDTO content, CancellationToken cancellationToken = default)
        {
            var error = await ValidateAsync(content, cancellationToken);
            if (error != null) return error;

            if (!await unitOfWork.PersonRepository.UpdateAsync(content, cancellationToken))
                return new DatabaseError();

            return true;
        }

        private async Task<BaseError?> ValidateAsync(RequestUpdatePersonDTO content, CancellationToken cancellationToken = default)
        {
            if (content.Name.Length > PersonContants.MAX_NAME_LENGTH)
                return new PersonNameMaxLengthError(PersonContants.MAX_NAME_LENGTH);

            if (!await unitOfWork.PersonRepository.AnyAsync(x => x.Id == content.Id, cancellationToken))
                return new PersonNotFoundError();

            return null;
        }
    }
}
