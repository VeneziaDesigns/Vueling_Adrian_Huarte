using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M.Domain.DomainEntities;

namespace M.Domain.RepositoryContracts
{
    public interface IMarianicoRepository
    {
        List<Frase> GetAllFrases();
        Frase GetFraseById(int id);
        List<Frase> GetFraseByDate(string fecha);
        int AddFrase(Frase frase);
    }
}
