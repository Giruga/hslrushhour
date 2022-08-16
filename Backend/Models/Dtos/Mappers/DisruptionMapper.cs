namespace HSLRushHour.Backend.Models.Dtos.Mappers;
public static class DisruptionMapper
{
    public static DisruptionDto toDto(this Disruption d)
    {
        var (dbRouteProvider, dbRouteNumber, _) = d.route?.gtfsId.Split(':');

        return new DisruptionDto()
        {
            header = d.header,
            description = d.description,
            start = d.start,
            end = d.end,
            routeProvider = dbRouteProvider,
            routeNumber = dbRouteNumber.Length > 0 ? Int32.Parse(dbRouteNumber) : null
        };
    }
}