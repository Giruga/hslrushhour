using HSLRushHour.Backend.Shared.Dtos;

namespace HSLRushHour.Backend.Clients.DigiTransitClient.GraphQLModels;

public static class DisruptionMapper
{
    public static DisruptionDto toDto(this DisruptionModel d)
    {
        return new DisruptionDto()
        {
            id = d.id,
            header = d.alertHeaderText,
            description = d.alertDescriptionText,
            start = new DateTime(d.effectiveStartDate),
            end = new DateTime(d.effectiveEndDate),
            routeNumber = d.route != null ? $"{d.route.shortName} : {d.route.longName}" : null,
            routeProvider = null
        };
    }
}
