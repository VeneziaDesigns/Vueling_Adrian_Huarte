
using System;
using System.Collections.Generic;
using System.Linq;
using DomainEntities;

namespace Repositories
{
    public class ITWorkersRepository
    {
        private List<ITWorker> _workers;
        private List<string> _techKnowledges;

        public ITWorkersRepository()
        {
            _techKnowledges = new List<string> { ".NET", "Java", "React", "Python", "SQL", "Kotlin", "PHP" };
            _workers = new List<ITWorker>
            {
                new ITWorker("Pepito", "Grillo", new DateTime(1990, 08, 14), 5,
                            _techKnowledges.Where(t => t.StartsWith("Java") &&
                            t.StartsWith("SQL")).ToList(), Level.Senior),

                new ITWorker("Chapulin", "Colorado", new DateTime(1985, 02, 15), 4,
                            _techKnowledges.Where(t => t.StartsWith(".NET") &&
                            t.StartsWith("PHP")).ToList(), Level.Medium),

                new ITWorker("Fula", "Nito", new DateTime(1975, 09, 28), 3,
                            _techKnowledges.Where(t => t.StartsWith("React") &&
                            t.StartsWith("Kotlin")).ToList(), Level.Medium),

                new ITWorker("Meng", "Anito", new DateTime(2002, 11, 21), 2,
                            _techKnowledges.Where(t => t.StartsWith(".NET") &&
                            t.StartsWith("React")).ToList(), Level.Junior),

                new ITWorker("Stelio", "Kontos", new DateTime(2005, 05, 03), 1,
                            _techKnowledges.Where(t => t.StartsWith("PHP") &&
                            t.StartsWith("SQL")).ToList(), Level.Junior),
            };
        }

        public List<ITWorker> GetWorkers()
        {
            return _workers;
        }

        public void SetWorkers(List<ITWorker> newDataWorkers)
        {
            _workers = newDataWorkers;
        }
    }
}
