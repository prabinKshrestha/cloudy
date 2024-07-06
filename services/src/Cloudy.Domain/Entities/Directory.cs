namespace Cloudy.Domain.Entities;

public class CloudyDirectory: BaseAccountEntity
{
    public required string Name { get; set; }

    public Guid? ParentId { get; set; }
    public virtual CloudyDirectory? Parent { get; set; }

    public ICollection<CloudyDirectory> Children { get; set; } = [];
    public ICollection<CloudyFile> Files { get; set; } = [];

}
