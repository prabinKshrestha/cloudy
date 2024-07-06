using Cloudy.Application.Common.Interfaces;
using Cloudy.Domain.Entities;

namespace Cloudy.Application.Directories.Queries;

public record GetDirectoriesByParentIdQuery(Guid DirectoryId) : IRequest<List<DirectoryDto>>;

public class GetTodoItemsWithPaginationQueryHandler(ICloudyDbContext context)
    : IRequestHandler<GetDirectoriesByParentIdQuery, List<DirectoryDto>>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<List<DirectoryDto>> Handle(GetDirectoriesByParentIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Directories
            .Where(x => x.ParentId == request.DirectoryId)
            .Select(x => new DirectoryDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);
    }
}
