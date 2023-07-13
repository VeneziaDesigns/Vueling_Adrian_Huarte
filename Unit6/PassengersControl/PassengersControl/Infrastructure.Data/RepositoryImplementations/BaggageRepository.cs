using Domain.DomainEntities;
using System.Text.Json;
using Domain.RepositoryContracts;
using Infrastructure.Data.DataModels;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.RepositoryImplementations
{
    public class BaggageRepository : IBaggageRepository
    {
        public readonly string? _url;

        public BaggageRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiUrlSettings:BaggageUrl").Value;
        }

        public List<Baggage>? GetBaggageInfo()
        {
            using HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, _url);
            HttpResponseMessage response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                using StreamReader reader = new(response.Content.ReadAsStream());
                string content = reader.ReadToEnd();

                List<BaggageFromJson>? baggageJson = JsonSerializer.Deserialize<List<BaggageFromJson>>(content);

                var baggage = MapJsonToDomainEntity(baggageJson);

                return baggage;
            }

            return null;
        }
        private static List<Baggage>? MapJsonToDomainEntity(List<BaggageFromJson>? baggageJson)
        {
            List<Baggage> baggage = baggageJson.Select(p => new Baggage
            {
                BaggageId = p.BaggageId,
                PassengerId = p.PassengerId,
                Weight = p.Weight,
                BaggageType = p.BaggageType,
            }).ToList();

            return baggage;
        }
    }
}
