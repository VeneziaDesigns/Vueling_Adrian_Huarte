using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MusicianDomain.CustomExceptions;
using MusicianDomain.DomainEntities;
using MusicianDomain.RepositoryContracts;
using MusicianRepository.DataModels;

namespace MusicianRepository.RepositoryImplementations
{
    public class MusicosRepository : IMusicosRepository
    {
        private readonly string? _url;

        public MusicosRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiSettings").GetSection("MusicosUrl").Value;
        }

        public List<Musicos>? GetMusicians()
        {
            List<Musicos> allMusicians;

            using HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, _url);

            HttpResponseMessage response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                using var reader = new StreamReader(response.Content.ReadAsStream());
                string content = reader.ReadToEnd();

                List<MusiciansInfoFromJson> listFromJson = JsonSerializer.Deserialize<List<MusiciansInfoFromJson>>(content) ?? new List<MusiciansInfoFromJson>();

                return allMusicians = MapToDomainEntity(listFromJson);
            }
            else
            {
                throw new ResourceNotAvailableException("The resource is not available");
            }
        }

        private static List<Musicos> MapToDomainEntity(List<MusiciansInfoFromJson> listFromJson)
        {
            return listFromJson.Select(dataFromJson => new Musicos
            {
                Nombre = dataFromJson.Name,
                Categorias = dataFromJson.Roles.Split(',').Select(x => x.ToLower()).ToList()
            }).ToList();
        }
    }
}
