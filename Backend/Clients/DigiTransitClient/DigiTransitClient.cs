using GraphQL;
using GraphQL.Client.Abstractions;
using HSLRushHour.Backend.Clients.DigiTransitClient.GraphQLCollectionTypes;
using HSLRushHour.Backend.Clients.DigiTransitClient.GraphQLModels;
using HSLRushHour.Backend.Shared.Dtos;

namespace HSLRushHour.Backend.Clients.DigiTransitClient;

public interface IDigiTransitClient
{
    Task<IEnumerable<DisruptionDto>> getDisturbances();
}

public class DigiTransitClient : IDigiTransitClient
{
    private readonly IGraphQLClient _client;

    public DigiTransitClient(IGraphQLClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<DisruptionDto>> getDisturbances()
    {

        var query = new GraphQLRequest
        {
            @Query = @"
                query disturbanceQuery 
                {
                    alerts {
                        alertHeaderText
                        alertDescriptionText
                        alertUrl
                        effectiveStartDate
                        effectiveEndDate
                        route {
                            shortName
                            longName
                        }
                        stop {      
                            name
                            code
                        }
                    }
                } 
            "
        };

        var result = await _client.SendQueryAsync<ResponseDisturbanceCollectionType>(query);
        return result.Data.Disruptions.Select(x => x.toDto());
    }
}
