namespace PingMonitor.WebApi;

public class PingLogEntryEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public bool Success { get; set; }
    public long RoundtripTime { get; set; }
}


