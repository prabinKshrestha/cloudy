using Cloudy.Application.Files.Commands.CreateFile;
using Cloudy.Application.Files.Commands.UpdateFile;
using Cloudy.Application.Files.Queries;

namespace Cloudy.Api.Endpoints;

public class File : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateFile)
            .MapDelete(DeleteFiles)
            .MapPut(UpdateFile, "{fileId}");

        app.MapGroup("directories")
            .MapGet(GetFilesByDirectoryId, "{directoryId}/files");
    }

    public Task<Guid> CreateFile(ISender sender, CreateFileCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateFile(ISender sender, Guid fileId, UpdateFileCommand command)
    {
        if (fileId != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteFiles(ISender sender, DeleteFileCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }

    public Task<List<FileDto>> GetFilesByDirectoryId(ISender sender, Guid directoryId)
    {
        return sender.Send(new GetFilesByDirectoryIdQuery(directoryId));
    }
}
