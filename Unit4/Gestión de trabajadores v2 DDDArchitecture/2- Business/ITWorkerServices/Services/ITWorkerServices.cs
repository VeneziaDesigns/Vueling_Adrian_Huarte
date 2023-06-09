using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using Repositories;
using Services.IServices;

namespace Services
{
    public class ITWorkerServices : IWorkersServices
    {
        private readonly IWorkersRepository _workersRepository;

        public ITWorkerServices(IWorkersRepository workersRepository)
        {
            _workersRepository = workersRepository;
        }

        public List<ITWorker> GetTeamMembersByTeamName(string teamName)
        {
            throw new NotImplementedException();
        }

        public void RegisterNewITWorker(ITWorker worker)
        {
            
        }

        public void UnregisterWorker(int workerId)
        {
            throw new NotImplementedException();
        }
    }
}
