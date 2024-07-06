using Cloudy.Application.Common.Interfaces;
using Cloudy.Domain.Entities;

namespace Cloudy.Application.Files.Commands.CreateFile;

public record CreateFileCommand(string FileName, string FileType, Guid DirectoryId, Guid AccountId, byte[] Content) : IRequest<Guid>;

public class CreateFileCommandHandler(ICloudyDbContext context)
    : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var name = Path.GetFileNameWithoutExtension(request.FileName);
        var extension = Path.GetExtension(request.FileName);

        var file = new CloudyFile
        {
            AccountId = request.AccountId,
            Name = name,
            Extension = extension,
            FileType = request.FileType,
            DirectoryId = request.DirectoryId,
            NameInCloud = StoreFileAndGetNameInCloud(request),
        };

        _context.Files.Add(file);
        await _context.SaveChangesAsync(cancellationToken);

        return file.Id;
    }

    private static Guid StoreFileAndGetNameInCloud(CreateFileCommand request)
    {
        return Guid.NewGuid();
    }
}
