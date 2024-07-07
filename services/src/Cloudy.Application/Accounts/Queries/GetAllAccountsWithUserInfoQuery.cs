using Cloudy.Application.Common.Interfaces;

namespace Cloudy.Application.Accounts.Queries;

public record AccountUserDto(Guid Id, string AccountName, string UserEmail);

public record GetAllAccountsWithUserInfoQuery() : IRequest<List<AccountUserDto>>;

public class GetAllAccountsWithUserInfoQueryHandler(ICloudyDbContext context)
    : IRequestHandler<GetAllAccountsWithUserInfoQuery, List<AccountUserDto>>
{
    private readonly ICloudyDbContext _context = context;

    public async Task<List<AccountUserDto>> Handle(GetAllAccountsWithUserInfoQuery request, CancellationToken cancellationToken)
    {
        return await _context.Accounts
            .Include(x => x.User)
            .Select(x => new AccountUserDto(x.Id, x.Name, x.User!.Email))
            .ToListAsync(cancellationToken);
    }
}
