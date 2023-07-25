using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public class AverageWeightByFlightResponse
    {
        [JsonPropertyName("Día")]
        public DateTime Day { get; set; }
        [JsonPropertyName("Vuelos")]
        public List<AverageWeight> Flights { get; set; } = new List<AverageWeight>();
    }
}
