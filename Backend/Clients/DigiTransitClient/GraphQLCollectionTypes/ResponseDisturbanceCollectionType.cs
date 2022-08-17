
namespace HSLRushHour.Backend.Clients.DigiTransitClient.GraphQLCollectionTypes;

public class ResponseDisturbanceCollectionType
{
    public IEnumerable<GraphQLModels.DisruptionModel> alerts { get; set; } = new List<GraphQLModels.DisruptionModel>();
}
