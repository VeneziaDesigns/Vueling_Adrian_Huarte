using MusicianDomain.DomainEntities;

namespace MusicianDomain.RepositoryContracts
{
    public interface IDiasOcupadosRepository
    {
        List<Musicos>? GetFreeDays(List<Musicos>? musicians, string date);
    }
}
