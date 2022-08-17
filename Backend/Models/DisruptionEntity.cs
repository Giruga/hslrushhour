namespace HSLRushHour.Backend.Models;

public class DisruptionEntity
{
    public Guid id { get; set; }
    public string header { get; set; } = "";
    public string description { get; set; } = "";
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    public BusRouteEntity? route { get; set; } = null;
}

public class BusRouteEntity
{
    public string gtfsId { get; set; } = "";
}
