using System.Text.Json;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.DataModels;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RepositoryImplementations
{
    public class BaggageRepository : IBaggageRepository
    {
        private readonly string? _url;

        public BaggageRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ResourcesSettings:Baggages").Value;
        }

        public async Task<List<BaggagesInfo>> GetBaggagesInfo()
        {
            using HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                using Stream responseStream = await response.Content.ReadAsStreamAsync();

                List<BaggageFromJson>? baggageFromJson = await JsonSerializer.DeserializeAsync<List<BaggageFromJson>>(responseStream);

                List<BaggagesInfo> result = MapToDomainEntity(baggageFromJson);

                return result;
            }

            return null;
        }

        private static List<BaggagesInfo> MapToDomainEntity(List<BaggageFromJson>? baggageFromJson)
        {
            List<BaggagesInfo>? baggage = baggageFromJson.Select(p => new BaggagesInfo
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
