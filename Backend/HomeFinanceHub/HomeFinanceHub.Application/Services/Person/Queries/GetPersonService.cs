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
        /// <summary>
        /// Serviço responsável por buscar as informações de uma pessoa específica,
        /// utilizando o repositório para acessar os dados e retornando um DTO com as informações da pessoa,
        /// ou um erro caso a pessoa não seja encontrada.
        /// É utilizado para buscar as informações a serem atualizadas.
        /// </summary>

        public async Task<OneOf<PersonDTO, BaseError>> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var person = await unitOfWork.PersonRepository.GetAsync(id, cancellationToken);

            if (person is null)
                return new PersonNotFoundError();

            return person;
        }
    }
}
