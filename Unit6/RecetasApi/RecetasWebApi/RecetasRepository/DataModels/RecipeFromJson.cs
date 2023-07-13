using System.Text.Json.Serialization;

namespace RecetasRepository.DataModels
{
    public class RecipeFromJson
    {
        [JsonPropertyName("nombre")]
        public string? Name { get; set; }

        [JsonPropertyName("ingredientes")]
        public Dictionary<string, decimal>? Ingredients { get; set; }

        [JsonPropertyName("minutosCocinado")]
        public int TimeMinutes { get; set; }
    }
}
