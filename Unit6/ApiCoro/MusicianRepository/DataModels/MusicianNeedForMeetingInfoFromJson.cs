using System.Text.Json.Serialization;

namespace MusicianRepository.DataModels
{
    public class MusicianNeedForMeetingInfoFromJson
    {
        [JsonPropertyName("category")]
        public string Role { get; set; } = "";

        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
