using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class AverageWeight
    {
        [JsonPropertyName("Id de vuelo")]
        public string? FlightId { get; set; } = string.Empty;

        [JsonPropertyName("Trayecto")]
        public string Journey { get; set; } = string.Empty;

        [JsonPropertyName("Media de peso de pasajeros")]
        public decimal? PassengersAverageWeight { get; set; }

        [JsonPropertyName("Media de peso del equipaje")]
        public decimal? BaggageAverageWeight { get; set; }
    }
}
