using HSLRushHour.Backend.Models;

namespace HSLRushHour.Backend.Shared.Dtos.Mappers;
public static class DisruptionMapper
{
    public static DisruptionDto toDto(this DisruptionEntity d)
    {
        var routeProvider = "";
        var routeNumber = "";
        if (d.route != null) {
            var (dbRouteProvider, dbRouteNumber, _) = d.route!.gtfsId.Split(':');
            routeProvider = dbRouteProvider;
            routeNumber = dbRouteNumber;
        }

        return new DisruptionDto()
        {
            id = d.digiTransitId,
            header = d.header,
            description = d.description,
            start = d.start,
            end = d.end,
            routeProvider = routeProvider,
            routeNumber = routeNumber.Length > 0 ? routeNumber : null
        };
    }

    public static DisruptionEntity toEntity(this DisruptionDto d)
    {
        return new DisruptionEntity()
        {
            digiTransitId = d.id,
            header = d.header,
            description = d.description,
            start = d.start,
            end = d.end,
            route = new BusRouteEntity()
            {
                gtfsId = $"{d.routeProvider}:{d.routeNumber}"
            }
        };
    }
}