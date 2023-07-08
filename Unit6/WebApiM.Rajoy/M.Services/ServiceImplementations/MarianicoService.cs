using M.Domain.DomainEntities;
using M.Domain.RepositoryContracts;
using M.Services.ServiceContracts;

namespace M.Services.ServiceImplementations
{
    public class MarianicoService : IMarianicoService
    {
        private readonly IMarianicoRepository _marianicoRepository;

        public MarianicoService(IMarianicoRepository fraseRepository)
        {
            _marianicoRepository = fraseRepository;
        }

        public List<Frase> GetAllFrases()
        {
            return _marianicoRepository.GetAllFrases();
        }

        public List<Frase> GetFraseByDate(string fecha)
        {
            return _marianicoRepository.GetFraseByDate(fecha);
        }

        public Frase GetFraseById(int id)
        {
            return _marianicoRepository.GetFraseById(id);
        }

        public int AddFrase(Frase frase)
        {
            return _marianicoRepository.AddFrase(frase);
        }
    }
}
