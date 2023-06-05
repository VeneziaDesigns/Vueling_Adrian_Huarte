using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Team
    {
        public string TeamName { get; }
        
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
