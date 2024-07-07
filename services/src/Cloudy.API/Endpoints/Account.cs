using Cloudy.Application.Accounts.Commands.CreateAccount;
using Cloudy.Application.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cloudy.Api.Endpoints;

public class Accounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.CustomMapGroup(this)
            .MapPost(CreateAccount)
            .MapGet(GetAllAccountsWithUserInfo);
    }

    public async Task<CreateAccountResponse> CreateAccount([FromServices] ISender sender, [FromBody] CreateAccountCommand command)
    {
        return await sender.Send(command);
    }

    public Task<List<AccountUserDto>> GetAllAccountsWithUserInfo(ISender sender)
    {
        return sender.Send(new GetAllAccountsWithUserInfoQuery());
    }
}
