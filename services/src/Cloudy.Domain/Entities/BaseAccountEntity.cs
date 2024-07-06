using Cloudy.Domain.Common;

namespace Cloudy.Domain.Entities;

public abstract class BaseAccountEntity: BaseAuditableEntity
{
    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
}
