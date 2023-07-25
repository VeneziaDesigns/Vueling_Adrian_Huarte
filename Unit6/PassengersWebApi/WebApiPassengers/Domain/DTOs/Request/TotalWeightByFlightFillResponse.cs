using System.Text.Json.Serialization;

namespace Domain.DTOs.Request
{
    public class TotalWeightByFlightFillResponse
    {
        [JsonPropertyName("Peso del tipo de equipaje por vuelo")]
        public decimal TotalWeight { get; set; }
    }
}
