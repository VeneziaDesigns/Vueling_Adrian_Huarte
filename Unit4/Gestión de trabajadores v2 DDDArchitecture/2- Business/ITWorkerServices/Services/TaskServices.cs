using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using Services.IServices;

namespace Services
{
    public class TaskServices : ITaskServices
    {
        public void RegisterNewTask(Tasks task)
        {
            throw new NotImplementedException();
        }

        public List<Tasks> ListUnassignedTasks()
        {
            throw new NotImplementedException();
        }

        public List<Tasks> ListTaskAssignmentsByTeamName(string teamName)
        {
            throw new NotImplementedException();
        }

        public void AssignTaskToWorker(int taskId, int workerId)
        {
            throw new NotImplementedException();
        }
    }
}
