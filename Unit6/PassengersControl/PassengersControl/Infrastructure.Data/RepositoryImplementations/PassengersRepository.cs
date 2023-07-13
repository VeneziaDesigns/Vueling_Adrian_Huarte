using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.Data.DataModels;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.RepositoryImplementations
{
    public class PassengersRepository : IPassengersRepository
    {
        public readonly string? _url;

        public PassengersRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiUrlSettings:PassengersUrl").Value;
        }

        public List<Passengers>? GetPassengersInfo()
        {
            using HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, _url);
            HttpResponseMessage response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                using StreamReader reader = new(response.Content.ReadAsStream());
                string content = reader.ReadToEnd();

                List<PassengersFromJson>? passengersJson = JsonSerializer.Deserialize<List<PassengersFromJson>>(content);

                var passengers = MapJsonToDomainEntity(passengersJson);

                return passengers;
            }

            return null;
        }
        private List<Passengers>? MapJsonToDomainEntity(List<PassengersFromJson>? passengersJson)
        {
            List<Passengers> passengers = passengersJson.Select(p => new Passengers
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
