using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class GetAllPassengersByDate
    {
        [JsonPropertyName("Nombre")]
        public string? Name { get; set; }
        [JsonPropertyName("Apellido")]
        public string? Surname { get; set; }
        [JsonPropertyName("Maleta de mano")]
        public bool CarryOn { get; set; }
    }
}
