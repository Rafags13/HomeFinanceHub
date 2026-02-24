using HomeFinanceHub.Domain.Constants.Person.Transaction.Category;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Errors.Persons.Transactions.Categories;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Commands;
using HomeFinanceHub.Domain.Interfaces.UoW;
using OneOf;
namespace HomeFinanceHub.Application.Services.Person.Transaction.Category.Commands
{
    internal sealed class CreateCategoryService(
        IUnitOfWork unitOfWork
    ) : ICreateCategoryService
    {
        /// <summary>
        /// Serviço responsável por criar uma categoria,
        /// validando o limite máximo de caracteres da descrição antes da persistência.
        /// </summary>
        public async Task<OneOf<bool, BaseError>> CreateAsync(RequestCreateCategoryDTO content, CancellationToken cancellationToken = default)
        {
            var error = Validate(content);
            if (error != null) return error;

            if (!await unitOfWork.CategoryRepository.CreateAsync(content, cancellationToken))
                return new DatabaseError();

            return true;
        }

        private static CategoryDescriptionMaxLengthError? Validate(RequestCreateCategoryDTO content)
        {
            if (content.Description.Length > CategoryContants.MAX_NAME_LENGTH)
                return new CategoryDescriptionMaxLengthError(CategoryContants.MAX_NAME_LENGTH);

            return null;
        }
    }
}
