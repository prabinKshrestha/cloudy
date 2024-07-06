using Cloudy.Domain.Common;

namespace Cloudy.Domain.Entities;


public class Account: BaseEntity
{
    public required string Name { get; set; }

    public virtual User? User { get; set; }
}