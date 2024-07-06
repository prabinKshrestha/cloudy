using Cloudy.Application.Common.Interfaces;
using Cloudy.Domain.Entities;

namespace Cloudy.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(string AccountName, string Email) : IRequest<CreateAccountResponse>;
public record CreateAccountResponse(Guid AccountId, Guid UserId);

public class CreateAccountCommandHandler(ICloudyDbContext context) 
    : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var directory = new CloudyDirectory
        {
            Name = request.AccountName,
            Account = new Account
            {
                Id = Guid.NewGuid(),
                Name = request.AccountName,
                User = new User
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                }
            }
        };

        _context.Directories.Add(directory);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateAccountResponse(directory.Account.Id, directory.Account.User.Id);
    }
}
