using Cloudy.Application.Common.Interfaces;

namespace Cloudy.Application.Accounts.Queries;

public record AccountUserDto(Guid Id, string AccountName, string UserEmail, Guid RootDirectoryId);

public record GetAllAccountsWithUserInfoQuery() : IRequest<List<AccountUserDto>>;

public class GetAllAccountsWithUserInfoQueryHandler(ICloudyDbContext context)
    : IRequestHandler<GetAllAccountsWithUserInfoQuery, List<AccountUserDto>>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<List<AccountUserDto>> Handle(GetAllAccountsWithUserInfoQuery request, CancellationToken cancellationToken)
    {
        var accounts = await (
                            from account in _context.Accounts
                            join dir in _context.Directories on account.Id equals dir.AccountId
                            where dir.ParentId == null
                            select new AccountUserDto(
                                account.Id,
                                account.Name,
                                account.User!.Email,
                                dir.Id
                            )
                        ).ToListAsync(cancellationToken);
        return accounts;
    }
}
