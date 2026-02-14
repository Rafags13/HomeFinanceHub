using System.ComponentModel.DataAnnotations;

namespace HomeFinanceHub.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; init; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
