using M.Domain.DomainEntities;

namespace M.Services.ServiceContracts
{
    public interface IMarianicoService
    {
        List<Frase> GetAllFrases();
        Frase GetFraseById(int id);
        List<Frase> GetFraseByDate(string fecha);
        int AddFrase(Frase frase);
    }
}
