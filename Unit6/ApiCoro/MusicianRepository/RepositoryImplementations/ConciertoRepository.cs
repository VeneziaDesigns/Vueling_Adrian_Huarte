using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MusicianDomain.DomainEntities;
using MusicianDomain.RepositoryContracts;
using MusicianRepository.DataModels;

namespace MusicianRepository.RepositoryImplementations
{
    public class ConciertoRepository : IConciertoRepository
    {
        private readonly string? _url;

        public ConciertoRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiSettings").GetSection("ConciertoUrl").Value;
        }

        
        public List<MusicianNeedForMeetingInfo>? GetTypes()
        {
            Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> listFromJson = GetDataFromJson();

            List<MusicianNeedForMeetingInfo>? result = MapToDomainEntity(listFromJson);

            return result;
        }

        private Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> GetDataFromJson()
        {
            using HttpClient client = new();
            HttpRequestMessage webRequest = new(HttpMethod.Get, _url);

            var response = client.Send(webRequest);
            StreamReader reader = new(response.Content.ReadAsStream());
            string content = reader.ReadToEnd();

            return JsonSerializer.Deserialize<Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>>>(content) ??
                new Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>>();
        }

        private static List<MusicianNeedForMeetingInfo> MapToDomainEntity(Dictionary<string, List<MusicianNeedForMeetingInfoFromJson>> dictionaryFromJson)
        {
            List<MusicianNeedForMeetingInfo> result = new();

            foreach (var MusicianNeedForMeetingInfo in dictionaryFromJson)
            {
                foreach (MusicianNeedForMeetingInfoFromJson need in MusicianNeedForMeetingInfo.Value)
                {
                    result.Add(new MusicianNeedForMeetingInfo
                    {
                        Role = need.Role.ToLower(),
                        Amount = need.Amount,
                    });
                }
            }

            return result;
        }
    }
}
