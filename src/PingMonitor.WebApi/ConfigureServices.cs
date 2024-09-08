using Microsoft.EntityFrameworkCore;
using PingMonitor.WebApi.Entities;

namespace PingMonitor.WebApi;
public static class ConfigureServices
{
    public static void AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=app.db"));

    }

    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentityApiEndpoints<ApplicationUserEntity>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static void AddPingWorker(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection("PingWorkerSettings").Get<PingWorkerSettings>()
            ?? throw new InvalidOperationException("PingWorkerSettings not found in configuration");

        services.AddSingleton<PingWorkerSettings>(settings);
        services.AddHostedService<PingWorker>();
    }
}
