using Cloudy.Application.Common.Interfaces;

namespace Cloudy.Application.Files.Commands.UpdateFile;

public record UpdateFileCommand(string Name, Guid Id) : IRequest;

public class UpdateFileCommandHandler(ICloudyDbContext context)
    : IRequestHandler<UpdateFileCommand>
{
    private readonly ICloudyDbContext _context = context;

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        var file = await _context.Files.FindAsync(keyValues: [request.Id], cancellationToken);

        if(file is not null)
        {
            file.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
