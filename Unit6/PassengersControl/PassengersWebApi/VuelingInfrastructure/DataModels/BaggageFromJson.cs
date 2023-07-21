using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VuelingInfrastructure.DataModels
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
