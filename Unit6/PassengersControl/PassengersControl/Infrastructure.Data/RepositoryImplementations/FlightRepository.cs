using Domain.DomainEntities;
using System.Text.Json;
using Domain.RepositoryContracts;
using Infrastructure.Data.DataModels;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.RepositoryImplementations
{
    public class FlightRepository : IFlightRepository
    {
        public readonly string? _url;

        public FlightRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiUrlSettings:FlightsUrl").Value;
        }

        public List<Flight>? GetFlightInfo()
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
        private static List<Flight>? MapJsonToDomainEntity(List<FlightFromJson>? flightsJson)
        {
            List<Flight> flights = flightsJson.Select(p => new Flight
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
