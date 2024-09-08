using PingMonitor.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PingMonitor.WebApi;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<DomainEntity> Domains => Set<DomainEntity>();
    public DbSet<PingLogEntity> PingLogs => Set<PingLogEntity>();
    public DbSet<PingLogEntryEntity> PingLogEntries => Set<PingLogEntryEntity>();
}

