using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace Services.IServices
{
    public interface IWorkersServices
    {
        void RegisterNewITWorker(ITWorker worker);
        void UnregisterWorker(int workerId);
        List<ITWorker> GetTeamMembersByTeamName(string teamName);
    }
}
