﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Worker
    {
        private static int WorkerIdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        //allow LeavingDate to have null value
        public DateTime? LeavingDate { get; set; }

        public Worker(string Name, string Surname, DateTime BirthDate,
                        DateTime? LeavingDate = null)
        {
            Id = WorkerIdCounter++;
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = BirthDate;
            this.LeavingDate = LeavingDate;
        }

        public Worker()
        {

        }
    }
}
