namespace Cloudy.Application.Files.Queries;

public record FileDto(Guid Id, string Name, string Extension, string FileType)
{
    public string FullName => $"{Name}.{Extension}";
}