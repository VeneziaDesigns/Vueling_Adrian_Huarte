using System.Collections.Generic;
using DomainEntities;

namespace Repositories
{
    public interface ITeamRepository
    {
        bool Delete(Team entity);
        List<Team> GetAll();
        Team GetByName(string teamName);
        bool Insert(Team entity);
        bool Update(Team entity);
    }
}