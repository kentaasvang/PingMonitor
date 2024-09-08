namespace PingMonitor.WebApi;

public class PingResult
{
    public DateTimeOffset Date { get; set; }
    public bool Success { get; set; }
    public long RoundtripTime { get; set; }
}
