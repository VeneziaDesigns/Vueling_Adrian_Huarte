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
    public class FlightRepository : IFlightRepository
    {
        public readonly string? _url;

        public FlightRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ResourcesSettings:Flights").Value;
        }

        public List<Flights>? GetFlightInfo()
        {
            using HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, _url);
            HttpResponseMessage response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                using StreamReader reader = new(response.Content.ReadAsStream());
                string content = reader.ReadToEnd();

                List<FlightFromJson>? flightsJson = JsonSerializer.Deserialize<List<FlightFromJson>>(content);

                var flights = MapJsonToDomainEntity(flightsJson);

                return flights;
            }

            return null;
        }
        private static List<Flights>? MapJsonToDomainEntity(List<FlightFromJson>? flightsJson)
        {
            List<Flights> flights = flightsJson.Select(p => new Flights
            {
                FlightId = p.FlightId,
                Departure = p.Departure,
                Arrival = p.Arrival,
                FlightDateWithoutHour = p.FlightDate,
            }).ToList();

            return flights;
        }
    }
}
