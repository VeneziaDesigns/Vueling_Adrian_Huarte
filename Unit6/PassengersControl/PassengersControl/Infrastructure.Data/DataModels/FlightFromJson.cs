using System.Text.Json.Serialization;

namespace Infrastructure.Data.DataModels
{
    public class FlightFromJson
    {
        [JsonPropertyName("flightId")]
        public string? FlightId { get; set; }

        [JsonPropertyName("departure")]
        public string? Departure { get; set; }

        [JsonPropertyName("arrival")]
        public string? Arrival { get; set; }

        [JsonPropertyName("flightDate")]
        public DateTime FlightDate { get; set; }
    }
}
