using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VuelingInfrastructure.DataModels
{
    public class PassengersFromJson
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("surname")]
        public string? Surname { get; set; }

        [JsonPropertyName("flightId")]
        public string? FlightId { get; set; }

        [JsonPropertyName("passengerId")]
        public string? PassengerId { get; set; }

        [JsonPropertyName("weight")]
        public decimal? Weight { get; set; }
    }
}
