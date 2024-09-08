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
    private readonly ILogger<PingWorkerRepository> _logger;

    public PingWorkerRepository(ILogger<PingWorkerRepository> logger, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<DomainEntity>> GetDomainsAsync()
    {
        return await _dbContext.Domains
            .Include(d => d.PingLog)
            .ToListAsync();
    }

    public async Task AddPingLogEntryAsync(PingLogEntryEntity pingLogEntry)
    {
        _logger.LogDebug("Adding ping log entry with date {date} and ping log id {pingLogId}", pingLogEntry.Date, pingLogEntry.PingLogEntityId);
        await _dbContext.PingLogEntries.AddAsync(pingLogEntry);
        await _dbContext.SaveChangesAsync();
    }
}
