using System.Collections.Generic;
using DomainEntities;

namespace Repositories
{
    public interface IWorkersRepository
    {
        bool Delete(ITWorker entity);
        List<ITWorker> GetAll();
        ITWorker GetById(int id);
        bool Insert(ITWorker entity);
        bool Update(ITWorker entity);
    }
}