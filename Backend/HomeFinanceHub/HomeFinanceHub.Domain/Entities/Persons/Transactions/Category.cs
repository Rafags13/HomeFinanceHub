using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request;
using HomeFinanceHub.Domain.Entities.Common;
using HomeFinanceHub.Domain.Enums.Transaction;

namespace HomeFinanceHub.Domain.Entities.Persons.Transactions
{
    public class Category : BaseEntity
    {
        public string Description { get; init; } = string.Empty;
        public EExpenseCategoryType PurposeType { get; init; }

        protected Category() { }

        public Category(RequestCreateCategoryDTO content)
        {
            Description = content.Description;
            PurposeType = content.PurposeType;
        }

        #region [Navigations]
        public ICollection<Transaction> Transactions { get; private set; } = [];
        #endregion
    }
}
