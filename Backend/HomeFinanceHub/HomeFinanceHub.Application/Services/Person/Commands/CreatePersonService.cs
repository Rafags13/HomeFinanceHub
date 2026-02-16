using HomeFinanceHub.Domain.Constants.Person;
using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Errors.Persons;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Commands;
using HomeFinanceHub.Domain.Interfaces.UoW;
using OneOf;

namespace HomeFinanceHub.Application.Services.Person.Commands
{
    internal sealed class CreatePersonService(
        IUnitOfWork unitOfWork
    ) : ICreatePersonService
    {
        public async Task<OneOf<bool, BaseError>> CreateAsync(RequestCreatePersonDTO content, CancellationToken cancellationToken = default)
        {
            var error = Validate(content);
            if (error != null) return error;

            if (!await unitOfWork.PersonRepository.CreateAsync(content, cancellationToken))
                return new DatabaseError();

            return true;
        }

        private static BaseError? Validate(RequestCreatePersonDTO content)
        {
            if (content.Name.Length > PersonContants.MAX_NAME_LENGTH)
                return new PersonNameMaxLengthError(PersonContants.MAX_NAME_LENGTH);

            return null;
        }
    }
}
