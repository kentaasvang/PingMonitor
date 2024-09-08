namespace PingMonitor.WebApi.Entities;

public class PingLogEntity
{
    public Guid Id { get; set; }
    public DomainEntity Domain { get; set; } = null!;
    public List<PingLogEntryEntity> PingLogItems { get; set; } = new();
}
