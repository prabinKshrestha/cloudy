using Cloudy.Application.Common.Interfaces;
using Cloudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cloudy.Infrastructure.Data;

public class CloudyDbContext(DbContextOptions<CloudyDbContext> options) : DbContext(options), ICloudyDbContext
{
    public DbSet<Account> Accounts  => Set<Account>();
    public DbSet<User> Users   => Set<User>();
    public DbSet<CloudyDirectory> Directories => Set<CloudyDirectory>();
    public DbSet<CloudyFile> Files   => Set<CloudyFile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<User>(u => u.AccountId);

        modelBuilder.Entity<CloudyFile>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<CloudyDirectory>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<CloudyDirectory>()
            .HasMany(d => d.Children)
            .WithOne(d => d.Parent)
            .HasForeignKey(d => d.ParentId);
    }
}