using Cloudy.Application.Common.Interfaces;

namespace Cloudy.Application.Files.Commands.DeleteFile;

public record DeleteFileCommand(List<Guid> FileIds) : IRequest;

public class DeleteFileCommandHandler(ICloudyDbContext context)
    : IRequestHandler<DeleteFileCommand>
{
    private readonly ICloudyDbContext _context = context;

    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        await _context.Files.Where(x => request.FileIds.Contains(x.Id)).ExecuteDeleteAsync(cancellationToken);
    }
}
