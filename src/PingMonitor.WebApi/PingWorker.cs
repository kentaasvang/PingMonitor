using System.Net.NetworkInformation;
 
namespace PingMonitor.WebApi;

public class PingWorker : BackgroundService
{
    private readonly ILogger<PingWorker> _logger;
    private readonly PingWorkerSettings _settings;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PingWorker(ILogger<PingWorker> logger, PingWorkerSettings settings, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _settings = settings;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var pingWorkerRepository 
                = scope.ServiceProvider.GetRequiredService<IPingWorkerRepository>();

            _logger.LogInformation("PingWorker running at: {time}", DateTimeOffset.Now);

            var domains = await pingWorkerRepository.GetDomainsAsync();

            foreach (var domain in domains)
            {
                var ping = new Ping();
                var pingResult = await ping.SendPingAsync(domain.Host);

                var pingLogEntry = new PingLogEntryEntity
                {
                    Date = DateTimeOffset.Now,
                    Success = pingResult.Status == IPStatus.Success,
                    RoundtripTime = pingResult.RoundtripTime,
                    PingLogEntityId = domain.PingLog.Id
                };

                _logger.LogDebug("Ping result: {result}", pingResult.Status);
                _logger.LogDebug("Roundtrip time: {time}", pingResult.RoundtripTime);
                _logger.LogDebug("Date: {date}", DateTimeOffset.Now);

                await pingWorkerRepository.AddPingLogEntryAsync(pingLogEntry);
            }

            _logger.LogDebug("Finished pinging {count} domains", domains?.Count);
            _logger.LogDebug("Waiting for {interval} milliseconds", _settings.IntervalInMilliseconds);


            await Task.Delay(_settings.IntervalInMilliseconds, stoppingToken);
        }
    }
}
