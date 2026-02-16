using HomeFinanceHub.Domain.Constants.Person.Transaction;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.Enums.Transaction;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Errors.Persons;
using HomeFinanceHub.Domain.Errors.Persons.Transactions;
using HomeFinanceHub.Domain.Errors.Persons.Transactions.Categories;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Commands;
using HomeFinanceHub.Domain.Interfaces.UoW;
using OneOf;

namespace HomeFinanceHub.Application.Services.Person.Transaction.Commands
{
    internal sealed class CreateTransactionService(
        IUnitOfWork unitOfWork
    ) : ICreateTransactionService
    {
        public async Task<OneOf<bool, BaseError>> CreateAsync(RequestCreateTransactionDTO content, CancellationToken cancellationToken = default)
        {
            var error = await ValidateAsync(content, cancellationToken);
            if (error != null) return error;

            if (!await unitOfWork.TransactionRepository.CreateAsync(content, cancellationToken))
                return new DatabaseError();

            return true;
        }

        private async Task<BaseError?> ValidateAsync(RequestCreateTransactionDTO content, CancellationToken cancellationToken = default)
        {
            var personValidationError = await ValidatePersonErrorAsync(content.PersonId, content.Type, cancellationToken);

            if (personValidationError != null)
                return personValidationError;

            return await ValidateCategoryErrorAsync(content.CategoryId, content.Type, cancellationToken);
        }

        private async Task<BaseError?> ValidatePersonErrorAsync(long personId, EExpenseCategoryType transactionType, CancellationToken cancellationToken = default)
        {
            var personAge = await unitOfWork.PersonRepository.GetAgeAsync(personId, cancellationToken);
            if (!personAge.HasValue)
                return new PersonNotFoundError();

            if (transactionType == EExpenseCategoryType.Revenue && personAge < TransactionContants.MIN_REVENUE_TRANSACTION_AGE)
                return new TransactionRevenueAgeError(TransactionContants.MIN_REVENUE_TRANSACTION_AGE);

            return null;
        }

        private async Task<BaseError?> ValidateCategoryErrorAsync(long categoryId, EExpenseCategoryType transactionType, CancellationToken cancellationToken = default)
        {
            var categoryPurposeType = await unitOfWork.CategoryRepository.GetPurposeTypeAsync(categoryId, cancellationToken);

            if (!categoryPurposeType.HasValue)
                return new CategoryNotFoundError();

            if (categoryPurposeType != EExpenseCategoryType.Both && transactionType != categoryPurposeType)
                return new TransactionCategoryTypeError();

            return null;
        }
    }
}
