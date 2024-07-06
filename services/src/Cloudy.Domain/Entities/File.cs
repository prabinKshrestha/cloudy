namespace Cloudy.Domain.Entities;

public class CloudyFile: BaseAccountEntity
{
    public required string Name { get; set; }
    public required string Extension { get; set; }
    public required string FileType { get; set; }
    public Guid NameInCloud { get; set; }
    public Guid DirectoryId { get; set; }
    public virtual CloudyDirectory? Directory { get; set; }
}
