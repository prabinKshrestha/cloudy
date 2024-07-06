using Cloudy.Application.Accounts.Commands.CreateAccount;
using Microsoft.AspNetCore.Mvc;

namespace Cloudy.Api.Endpoints;

public class Accounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateAccount);
    }

    public async Task<CreateAccountResponse> CreateAccount([FromServices] ISender sender, [FromBody] CreateAccountCommand command)
    {
        return await sender.Send(command);
    }
}
