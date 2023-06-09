using System.Collections.Generic;
using DomainEntities;

namespace Repositories
{
    public interface ITasksRepository
    {
        bool Delete(Tasks entity);
        List<Tasks> GetAll();
        Tasks GetById(int id);
        bool Insert(Tasks entity);
        bool Update(Tasks entity);
    }
}