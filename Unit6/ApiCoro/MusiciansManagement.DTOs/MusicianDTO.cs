using System.Text.Json.Serialization;

namespace MusiciansManagement.DTOs
{
    public class MusicianDTO
    {
        public MusicianDTO()
        {
            Name = "";
            Role = "";
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Músico")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Categoría")]
        public string Role { get; set; }
    }
}
