using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Errors.Persons;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using HomeFinanceHub.Domain.Interfaces.UoW;
using OneOf;

namespace HomeFinanceHub.Application.Services.Person.Queries
{
    internal sealed class GetPersonService(
        IUnitOfWork unitOfWork
    ) : IGetPersonService
    {
        public async Task<OneOf<PersonDTO, BaseError>> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var person = await unitOfWork.PersonRepository.GetAsync(id, cancellationToken);

            if (person is null)
                return new PersonNotFoundError();

            return person;
        }
    }
}
