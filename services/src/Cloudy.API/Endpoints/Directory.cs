using Cloudy.Application.Directories.Commands.CreateDirectory;
using Cloudy.Application.Directories.Commands.UpdateDirectory;
using Cloudy.Application.Directories.Queries;

namespace Cloudy.Api.Endpoints;

public class Directories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetDirectoriesByParentId, "{directoryId}/children")
            .MapPost(CreateDirectory)
            .MapPut(UpdateDirectory, "{directoryId}");
    }

    public Task<Guid> CreateDirectory(ISender sender, CreateDirectoryCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateDirectory(ISender sender, Guid directoryId, UpdateDirectoryCommand command)
    {
        if (directoryId != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public Task<List<DirectoryDto>> GetDirectoriesByParentId(ISender sender, Guid directoryId)
    {
        return sender.Send(new GetDirectoriesByParentIdQuery(directoryId));
    }
}
