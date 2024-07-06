using Cloudy.Application.Common.Interfaces;

namespace Cloudy.Application.Files.Queries;

public record GetFilesByDirectoryIdQuery(Guid DirectoryId) : IRequest<List<FileDto>>;

public class GetTodoItemsWithPaginationQueryHandler(ICloudyDbContext context)
    : IRequestHandler<GetFilesByDirectoryIdQuery, List<FileDto>>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<List<FileDto>> Handle(GetFilesByDirectoryIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Files
            .Where(x => x.DirectoryId == request.DirectoryId)
            .Select(x => new FileDto(x.Id, x.Name, x.Extension, x.FileType))
            .ToListAsync(cancellationToken);
    }
}
