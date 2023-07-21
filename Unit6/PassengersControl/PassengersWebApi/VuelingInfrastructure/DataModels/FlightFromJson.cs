using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VuelingInfrastructure.DataModels
{
    public class FlightFromJson
    {
        [JsonPropertyName("flightId")]
        public string? FlightId { get; set; }

        [JsonPropertyName("departure")]
        public string? Departure { get; set; }

        [JsonPropertyName("arrival")]
        public string? Arrival { get; set; }

        [JsonPropertyName("flightDate")]
        public DateTime FlightDate { get; set; }
    }
}
