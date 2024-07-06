using Cloudy.Application.Common.Interfaces;
using Cloudy.Domain.Entities;

namespace Cloudy.Application.Directories.Commands.CreateDirectory;

public record CreateDirectoryCommand(Guid AccountId, string Name, Guid ParentId) : IRequest<Guid>;

public class CreateDirectoryCommandHandler(ICloudyDbContext context)
    : IRequestHandler<CreateDirectoryCommand, Guid>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<Guid> Handle(CreateDirectoryCommand request, CancellationToken cancellationToken)
    {
        var rootDirectory = await _context.Directories.FirstOrDefaultAsync(d => d.AccountId == request.AccountId && d.ParentId == null, cancellationToken)
                            ?? throw new Exception("No root found.");
                            
        var directory = new CloudyDirectory
        {
            Name = request.Name,
            AccountId = rootDirectory.AccountId,
            ParentId = rootDirectory.Id
        };

        _context.Directories.Add(directory);
        await _context.SaveChangesAsync(cancellationToken);

        return directory.Id;
    }
}
