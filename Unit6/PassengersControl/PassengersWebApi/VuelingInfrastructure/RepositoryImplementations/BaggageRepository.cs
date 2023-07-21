using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VuelingDomain.DomainEntities;
using VuelingDomain.RepositoryContracts;
using VuelingInfrastructure.DataModels;

namespace VuelingInfrastructure.RepositoryImplementations
{
    public class BaggageRepository : IBaggageRepository
    {
        public readonly string? _url;

        public BaggageRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ResourcesSettings:Baggage").Value;
        }

        public List<Baggages>? GetBaggageInfo()
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
        private static List<Baggages>? MapJsonToDomainEntity(List<BaggageFromJson>? baggageJson)
        {
            List<Baggages> baggage = baggageJson.Select(p => new Baggages
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
