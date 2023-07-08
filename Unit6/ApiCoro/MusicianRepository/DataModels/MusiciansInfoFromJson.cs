using System.Text.Json.Serialization;

namespace MusicianRepository.DataModels
{
    public class MusiciansInfoFromJson
    {
        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = "";

        [JsonPropertyName("Categorias")]
        public string Roles { get; set; } = "";
    }
}
