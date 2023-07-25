using System.Collections.Generic;
using System.Text.Json;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.DataModels;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RepositoryImplementations
{
    public class PassengersRepository : IPassengersRepository
    {
        private readonly string? _url;

        public PassengersRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ResourcesSettings:Passenggers").Value;
        }

        public async Task<List<PassengersInfo>> GetPassengersInfo()
        {
            using HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                using Stream responseStream = await response.Content.ReadAsStreamAsync();
                
                List<PassengersFromJson>? passengersFromJson = await JsonSerializer.DeserializeAsync<List<PassengersFromJson>>(responseStream);

                List<PassengersInfo> result = MapToDomainEntity(passengersFromJson);

                return result;
            }

            return null;
        }

        private static List<PassengersInfo> MapToDomainEntity(List<PassengersFromJson>? passengersFromJson)
        {
            List<PassengersInfo> passengers = passengersFromJson.Select(p => new PassengersInfo
            {
                Name = p.Name,
                Surname = p.Surname,
                FlightId = p.FlightId,
                PassengerId = p.PassengerId,
                Weight = p.Weight,
            }).ToList();

            return passengers;
        }
    }
}
