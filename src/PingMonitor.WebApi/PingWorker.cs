using System.Net.NetworkInformation;
 
namespace PingMonitor.WebApi;

public class PingWorker : BackgroundService
{
    private readonly ILogger<PingWorker> _logger;
    private readonly PingWorkerSettings _settings;

    public PingWorker(ILogger<PingWorker> logger, PingWorkerSettings settings)
    {
        _logger = logger;
        _settings = settings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("PingWorker running at: {time}", DateTimeOffset.Now);

            var ping = new Ping();

            var pingResult = await ping.SendPingAsync("google.com");
            
            _logger.LogDebug("Ping result: {result}", pingResult.Status);
            _logger.LogDebug("Roundtrip time: {time}", pingResult.RoundtripTime);
            _logger.LogDebug("Date: {date}", DateTimeOffset.Now);

            _logger.LogDebug("Waiting for {interval} milliseconds", _settings.IntervalInMilliseconds);

            await Task.Delay(_settings.IntervalInMilliseconds, stoppingToken);
        }
    }
}
