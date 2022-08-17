using HSLRushHour.Backend.Models;

namespace HSLRushHour.Backend.Shared.Dtos.Mappers;
public static class DisruptionMapper
{
    public static DisruptionDto toDto(this DisruptionEntity d)
    {
        var (dbRouteProvider, dbRouteNumber, _) = d.route?.gtfsId.Split(':');

        return new DisruptionDto()
        {
            header = d.header,
            description = d.description,
            start = d.start,
            end = d.end,
            routeProvider = dbRouteProvider,
            routeNumber = dbRouteNumber.Length > 0 ? dbRouteNumber : null
        };
    }
}