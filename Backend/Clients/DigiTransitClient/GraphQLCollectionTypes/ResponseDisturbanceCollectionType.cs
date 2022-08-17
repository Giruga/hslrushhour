
namespace HSLRushHour.Backend.Clients.DigiTransitClient.GraphQLCollectionTypes;

public class ResponseDisturbanceCollectionType
{
    public IEnumerable<GraphQLModels.DisruptionModel> Disruptions { get; set; } = new List<GraphQLModels.DisruptionModel>();
}
