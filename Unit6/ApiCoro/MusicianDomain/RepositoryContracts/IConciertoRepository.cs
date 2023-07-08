using MusicianDomain.DomainEntities;

namespace MusicianDomain.RepositoryContracts
{
    public interface IConciertoRepository
    {
        List<MusicianNeedForMeetingInfo>? GetTypes();

    }
}
