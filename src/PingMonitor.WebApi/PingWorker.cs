//using System.Net.NetworkInformation;
 
namespace PingMonitor.WebApi;

public class PingWorker : BackgroundService
{
    private readonly ILogger<PingWorker> _logger;
    //private readonly IServiceScopeFactory _serviceScopeFactory;

    public PingWorker(ILogger<PingWorker> logger /*,IServiceScopeFactory serviceScopeFactory*/)
    {
        _logger = logger;
        //_serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("PingWorker running at: {time}", DateTimeOffset.Now);

            //using var scope = _serviceScopeFactory.CreateScope();
            //var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //var ping = new Ping();
            //var pingResult = await ping.SendPingAsync("google.com");

            /*
            var pingLog = new PingLog
            {
                Date = DateTimeOffset.Now,
                Success = pingResult.Status == IPStatus.Success,
                RoundtripTime = pingResult.RoundtripTime
            };
            */

            // dbContext.PingLogs.Add(pingLog);
            
            //await dbContext.SaveChangesAsync();

            await Task.Delay(1000, stoppingToken);
        }
    }
}
