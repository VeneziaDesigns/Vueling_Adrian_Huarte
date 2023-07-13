using System.Text.Json.Serialization;

namespace RecetasRepository.DataModels
{
    public class PriceByMinuteFromJson
    {
        [JsonPropertyName("CostePorMinuto")]
        public decimal? Price { get; set; }
    }
}
