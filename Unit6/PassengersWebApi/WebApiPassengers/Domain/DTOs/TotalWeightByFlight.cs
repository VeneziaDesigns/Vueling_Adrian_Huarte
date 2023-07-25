using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class TotalWeightByFlight
    {
        [JsonPropertyName("Día")]
        public DateTime Day { get; set; }

        [JsonPropertyName("Id de vuelo")]
        public string? FlightId { get; set; } = string.Empty;

        [JsonPropertyName("Trayecto")]
        public string Journey { get; set; } = string.Empty;

        [JsonPropertyName("Total de pasajeros")]
        public int PassengersNumber { get; set; }

        [JsonPropertyName("Peso total equipaje")]
        public decimal TotalWeight { get; set; }
    }
}
