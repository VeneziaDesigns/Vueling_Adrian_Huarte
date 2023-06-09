using System;
using System.Collections.Generic;
using System.Linq;
using DomainEntities;

namespace Repositories
{
    public class ITWorkersRepository : IWorkersRepository
    {
        private readonly List<ITWorker> _workers;
        private readonly List<string> _techKnowledges;

        public ITWorkersRepository()
        {
            _techKnowledges = new List<string> { ".NET", "Java", "React", "Python", "SQL", "Kotlin", "PHP" };
            _workers = new List<ITWorker>

            {
                new ITWorker
                {
                    Name = "Pepito",
                    Surname = "Grillo",
                    BirthDate = new DateTime(1990, 08, 14),
                    YearsOfExperience = 5,
                    TechKnowledges = new List<string> { _techKnowledges[1], _techKnowledges[2] },
                    WorkerLevel = Level.Senior
                },

                new ITWorker
                {
                    Name = "Chapulin",
                    Surname = "Colorado",
                    BirthDate = new DateTime(1975, 09, 28),
                    YearsOfExperience = 3,
                    TechKnowledges = new List<string> { _techKnowledges[3], _techKnowledges[4] },
                    WorkerLevel = Level.Medium
                },

                new ITWorker
                {
                    Name = "Meng",
                    Surname = "Anito",
                    BirthDate = new DateTime(1982, 07, 28),
                    YearsOfExperience = 2,
                    TechKnowledges = new List<string> { _techKnowledges[6] },
                    WorkerLevel = Level.Junior
                },

                new ITWorker
                {
                    Name = "Fula",
                    Surname = "Nito",
                    BirthDate = new DateTime(1990, 08, 14),
                    YearsOfExperience = 2,
                    TechKnowledges = new List<string> { _techKnowledges[5] },
                    WorkerLevel = Level.Junior
                },

                new ITWorker
                {
                    Name = "Stelio",
                    Surname = "Kontos",
                    BirthDate = new DateTime(1992, 08, 14),
                    YearsOfExperience = 1,
                    TechKnowledges = new List<string> { _techKnowledges[7] },
                    WorkerLevel = Level.Junior
                },
            };
        }
        public List<ITWorker> GetAll()
        {
            return _workers;
        }

        public ITWorker GetById(int id)
        {
            return _workers.FirstOrDefault(w => w.Id == id);
        }

        public bool Insert(ITWorker entity)
        {
            bool exist = _workers.Exists(w => w.Id.Equals(entity.Id));

            if (exist == true)
            {
                return false;
            }
            else
            {
                _workers.Add(entity);
                return true;
            }
        }

        public bool Update(ITWorker entity)
        {
            bool exist = _workers.Exists(t => t.Id.Equals(entity.Id));

            ITWorker findITWorker = _workers.Find(t => t.Id == entity.Id);

            if (findITWorker != null)
            {
                findITWorker = entity;
                return exist;
            }
            else
            {
                return exist;
            }
        }

        public bool Delete(ITWorker entity)
        {
            bool exist = _workers.Exists(t => t.Id.Equals(entity.Id));

            ITWorker findWorkers = _workers.Find(t => t.Id == entity.Id);

            if (exist)
            {
                _workers.Remove(findWorkers);
                return exist;
            }
            else
            {
                return exist;
            }
        }
    }
}

