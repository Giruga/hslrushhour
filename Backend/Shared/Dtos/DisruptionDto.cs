namespace HSLRushHour.Backend.Shared.Dtos;

public class DisruptionDto
{
    public string header { get; set; } = "";
    public string description { get; set; } = "";
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    public string? routeProvider { get; set; } = null;
    public string? routeNumber { get; set; } = null;
}
