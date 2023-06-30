using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSQLServer.DomainEntities;

namespace CrudDomain.RepositoryContracts
{
    public interface ICacheRepository
    {
        List<UserWorkers>? GetCache();
        bool SetCache(List<UserWorkers> cachingWorkers);
    }
}
