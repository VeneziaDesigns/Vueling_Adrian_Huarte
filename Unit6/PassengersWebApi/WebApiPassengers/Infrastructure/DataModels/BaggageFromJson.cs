using System.Text.Json.Serialization;

namespace Infrastructure.DataModels
{
    public class BaggageFromJson
    {
        [JsonPropertyName("baggageId")]
        public string? BaggageId { get; set; }

        [JsonPropertyName("passengerId")]
        public string? PassengerId { get; set; }

        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }

        [JsonPropertyName("type")]
        public string? BaggageType { get; set; }
    }
}
