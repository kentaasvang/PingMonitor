namespace PingMonitor.WebApi.Entities;

public class PingLogEntity
{
    public Guid Id { get; set; }
    public List<PingLogEntryEntity> PingLogItems { get; set; } = new();
}
