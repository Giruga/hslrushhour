namespace HSLRushHour.Backend.Clients.DigiTransitClient.GraphQLModels;

public class DisruptionModel
{
    public string id { get; set; } = "";
    public string alertHeaderText { get; set; } = "";
    public string alertDescriptionText { get; set; } = "";
    public string alertUrl { get; set; } = "";
    public long effectiveStartDate { get; set; }
    public long effectiveEndDate { get; set; }

    public RouteModel? route { get; set; } = null;
    public StopModel? stop { get; set; } = null;
}

public class RouteModel
{
    public string shortName { get; set; } = "";
    public string longName { get; set; } = "";
}

public class StopModel
{
    public string name { get; set; } = "";
    public string code { get; set; } = "";
}
