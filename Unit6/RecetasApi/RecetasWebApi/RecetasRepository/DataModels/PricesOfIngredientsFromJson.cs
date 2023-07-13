using System.Text.Json.Serialization;

namespace RecetasRepository.DataModels
{
    public class PricesOfIngredientsFromJson
    {
        [JsonPropertyName("nombre")]
        public string? Name { get; set; }

        [JsonPropertyName("precio")]
        public decimal? Price { get; set; }
    }
}
