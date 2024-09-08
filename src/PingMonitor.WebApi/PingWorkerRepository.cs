using PingMonitor.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace PingMonitor.WebApi;

public interface IPingWorkerRepository
{
    Task<List<DomainEntity>> GetDomainsAsync();
    Task AddPingLogEntryAsync(PingLogEntryEntity pingLogEntry);
}

public class PingWorkerRepository : IPingWorkerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PingWorkerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DomainEntity>> GetDomainsAsync()
    {
        return await _dbContext.Domains.ToListAsync();
    }

    public async Task AddPingLogEntryAsync(PingLogEntryEntity pingLogEntry)
    {
        await _dbContext.PingLogEntries.AddAsync(pingLogEntry);
        await _dbContext.SaveChangesAsync();
    }
}
