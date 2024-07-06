using Cloudy.Domain.Entities;

namespace Cloudy.Application.Common.Interfaces;

public interface ICloudyDbContext
{
    public DbSet<Account> Accounts { get; }
    public DbSet<User> Users { get; }
    public DbSet<CloudyDirectory> Directories { get; }
    public DbSet<CloudyFile> Files { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
