using System.Text.Json;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.DataModels;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RepositoryImplementations
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly string? _url;

        public FlightsRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ResourcesSettings:Flights").Value;
        }

        public async Task<List<FlightsInfo>> GetFlightsInfo()
        {
            using HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                using Stream responseStream = await response.Content.ReadAsStreamAsync();

                List<FlightFromJson>? flightFromJson = await JsonSerializer.DeserializeAsync<List<FlightFromJson>>(responseStream);

                List<FlightsInfo> result = MapToDomainEntity(flightFromJson);

                return result;
            }

            return null;
        }

        private static List<FlightsInfo> MapToDomainEntity(List<FlightFromJson>? flightFromJson)
        {
            List<FlightsInfo> flights = flightFromJson.Select(p => new FlightsInfo
            {
                FlightId = p.FlightId,
                Departure = p.Departure,
                Arrival = p.Arrival,
                FlightDate = p.FlightDate
            }).ToList();

            return flights;
        }
    }
}
