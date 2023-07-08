using MusicianDomain.DomainEntities;

namespace MusicianRepository.DataModels
{

    public class ConcertDataFromJson
    {
        public Dictionary<string, List<Musicos>> Dictionary { get; set; } = new();
    }
}
