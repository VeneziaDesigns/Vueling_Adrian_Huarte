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
    public class PassengerRepository : IPassengersRepository
    {
        public readonly string? _url;

        public PassengerRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ResourcesSettings:Passenggers").Value;
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
