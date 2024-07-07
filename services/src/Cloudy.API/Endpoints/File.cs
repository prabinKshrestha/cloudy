using Cloudy.Application.Files.Commands.CreateFile;
using Cloudy.Application.Files.Commands.DeleteFile;
using Cloudy.Application.Files.Commands.UpdateFile;
using Cloudy.Application.Files.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cloudy.Api.Endpoints;

public class Files : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.CustomMapGroup(this)
            .MapPost(CreateFile)
            .MapDelete(DeleteFiles)
            .MapPut(UpdateFile, "{fileId}");

        app.CustomMapGroup("directories")
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

    public async Task<IResult> DeleteFiles(ISender sender, [FromBody] DeleteFileCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }

    public Task<List<FileDto>> GetFilesByDirectoryId(ISender sender, Guid directoryId)
    {
        return sender.Send(new GetFilesByDirectoryIdQuery(directoryId));
    }
}
