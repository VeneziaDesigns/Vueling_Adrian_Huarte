using System.Text.Json.Serialization;

namespace Domain.DTOs.Request
{
    public class PassengersByFlightDateResponse
    {
        [JsonPropertyName("Día")]
        public DateTime Day { get; set; }
        [JsonPropertyName("Vuelos")]
        public List<FlightsPerDay> Flights { get; set; } = new List<FlightsPerDay>();
    }
}
