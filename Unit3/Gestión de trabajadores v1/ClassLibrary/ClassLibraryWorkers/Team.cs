using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryWorkers
{
    public class Team
    {
        public string TeamName { get; }
        //Only 1 Manager and list of Technicians
        public ITWorker Manager { get; set; }
        public List<ITWorker> Technicians { get; set; }

        public Team(string TeamName)
        {
            this.TeamName = TeamName;
            Technicians = new List<ITWorker>();
        }

        public void RemoveTechnician(ITWorker technician)
        {
            Technicians.Remove(technician);
        }

        public List<ITWorker> GetTechnicians()
        {
            return Technicians;
        }
    }
}
