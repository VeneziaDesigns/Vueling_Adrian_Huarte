using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public enum Level
    {
        Junior,
        Medium,
        Senior
    }
    public class ITWorker : Worker
    {
        public int YearsOfExperience { get; set; }
        public List<string> TechKnowledges { get; set; }
        public Level WorkerLevel { get; set; }

        public ITWorker(string Name, string Surname, DateTime BirthDate, int YearsOfExperience,
            List<string> TechKnowledges, Level WorkerLevel) : base(Name, Surname, BirthDate)
        {
            this.YearsOfExperience = YearsOfExperience;
            this.TechKnowledges = TechKnowledges;
            this.WorkerLevel = WorkerLevel;
        }
    }
}
