using Microsoft.Extensions.Configuration;
using MusicianDomain.CustomExceptions;
using MusicianDomain.DomainEntities;
using MusicianDomain.RepositoryContracts;
using MusicianRepository.DataModels;
using Newtonsoft.Json;

namespace MusicianRepository.RepositoryImplementations
{
    public class DiasOcupadosRepository : IDiasOcupadosRepository
    {
        private readonly string? _url;

        public DiasOcupadosRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiSettings").GetSection("DiasOcupadosUrl").Value;
        }

        public List<Musicos>? GetFreeDays(List<Musicos>? musicians, string date)
        {
            using HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, _url);

            HttpResponseMessage response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                using var reader = new StreamReader(response.Content.ReadAsStream());
                string content = reader.ReadToEnd();

                List<MusiciansAvailability>? ocupacionFechasMusicos = JsonConvert.DeserializeObject<List<MusiciansAvailability>>(content) ?? new List<MusiciansAvailability>();

                foreach (MusiciansAvailability? fecha in ocupacionFechasMusicos)
                {
                    Musicos? musico = musicians?.FirstOrDefault(m => m.Nombre.Equals(fecha.Nombre));

                    if (musico != null)
                    {
                        List<string>? fechasCoincidentes = fecha.Fechas.Where(f => fecha.Nombre == musico.Nombre).ToList();

                        musico.Fechas = fechasCoincidentes;
                    }
                }

                musicians = AvailableMusicians(musicians, date);

                return musicians;
            }
            else
            {
                throw new ResourceNotAvailableException("The resource is not available");
            }
        }

        private static List<Musicos>? AvailableMusicians(List<Musicos>? musicians, string date)
        {
            musicians?.RemoveAll(m => m.Fechas?.Contains(date) == true);
            return musicians;
        }
    }
}
