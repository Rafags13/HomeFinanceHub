using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.Entities.Common;
using HomeFinanceHub.Domain.Enums.Transaction;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinanceHub.Domain.Entities.Persons.Transactions
{
    public class Transaction : BaseEntity
    {
        public string? Description { get; init; }
        public decimal Value { get; init; }
        public EExpenseCategoryType Type { get; init; }
        public long CategoryId { get; init; }
        public long PersonId { get; init; }

        protected Transaction() { }

        public Transaction(RequestCreateTransactionDTO content)
        {
            Description = content.Description;
            Value = content.Value;
            Type = content.Type;
            CategoryId = content.CategoryId;
            PersonId = content.PersonId;
        }

        #region [Foreign Keys]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; private set; } = null!;

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; private set; } = null!;
        #endregion
    }
}
