using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace Services.IServices
{
    public interface ITaskServices
    {
        void RegisterNewTask(Tasks task);
        List<Tasks> ListUnassignedTasks();
        List<Tasks> ListTaskAssignmentsByTeamName(string teamName);
        void AssignTaskToWorker(int taskId, int workerId);
    }
}
