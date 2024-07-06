using Cloudy.Application.Common.Interfaces;

namespace Cloudy.Application.Directories.Commands.UpdateDirectory;

public record UpdateDirectoryCommand(Guid Id, string Name, Guid ParentId) : IRequest;

public class UpdateDirectoryCommandHandler(ICloudyDbContext context)
    : IRequestHandler<UpdateDirectoryCommand>
{
    private readonly ICloudyDbContext _context = context;

    public async Task Handle(UpdateDirectoryCommand request, CancellationToken cancellationToken)
    {
        var directory = await _context.Directories.FindAsync(keyValues: [request.Id], cancellationToken);

        if(directory is not null)
        {
            directory.Name = request.Name;
            directory.ParentId = request.ParentId;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
