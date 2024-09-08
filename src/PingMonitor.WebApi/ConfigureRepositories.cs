namespace PingMonitor.WebApi;

public static class ConfigureRepositories
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPingWorkerRepository, PingWorkerRepository>();
    }
}
