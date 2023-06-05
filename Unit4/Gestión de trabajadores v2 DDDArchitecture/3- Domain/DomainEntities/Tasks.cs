using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public enum TaskStatus
    {
        Todo,
        Doing,
        Done
    }
    public class Tasks
    {
        private static int taskIdCounter = 1;

        public int Id { get; }
        public string Description { get; }
        public string Technology { get; }
        public TaskStatus Status { get; }
        public int IdWorker { get; set; }

        public Tasks(string description, string technology, TaskStatus status)
        {
            Id = taskIdCounter++;
            Description = description;
            Technology = technology;
            Status = status;
            IdWorker = 0;
        }
    }
}
