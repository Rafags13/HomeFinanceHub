namespace HomeFinanceHub.Domain.Entities.Common
{
    public abstract class BaseDeletableEntity : BaseEntity
    {
        public DateTime? DeletedAt { get; private set; }

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;
        }
    }
}
