using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class FlightsPerDay
    {
        [JsonPropertyName("Id de vuelo")]
        public string? FlightId { get; set; } = string.Empty;

        [JsonPropertyName("Trayecto")]
        public string Journey { get; set; } = string.Empty;

        [JsonPropertyName("Pasajeros")]
        public List<GetAllPassengersByDate> Passengers { get; set; } = new List<GetAllPassengersByDate>();
    }
}
