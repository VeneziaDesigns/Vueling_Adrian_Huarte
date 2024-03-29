﻿using System.Text.Json.Serialization;

namespace Infrastructure.DataModels
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
        public decimal Weight { get; set; }
    }
}
