using System.Text.Json.Serialization;

namespace Domain.DTOs.Request
{
    public class TotalPassengersAndWeightFillByFlight
    {
        [JsonPropertyName("Total de pasajeros")]
        public int PassengersNumber { get; set; }

        [JsonPropertyName("Peso total")]
        public decimal TotalWeight { get; set; }

        [JsonPropertyName("Vuelos")]
        public List<TotalWeightByFlight> FlightsWeightBaggage { get; set; } = new List<TotalWeightByFlight>();
    }
}
