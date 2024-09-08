namespace PingMonitor.WebApi.Entities;

public class DomainEntity
{
    public Guid Id { get; set; }
    public string Host { get; set; } = null!;
    public PingLogEntity PingLog { get; set; } = null!;
}
