using System;
using System.Collections.Generic;
using System.Linq;
using DomainEntities;


namespace Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly List<Tasks> _tasks;



        public List<Tasks> GetAll()
        {
            return _tasks;
        }

        public Tasks GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public bool Insert(Tasks entity)
        {
            bool exist = _tasks.Exists(t => t.Id.Equals(entity.Id));

            if (exist == true)
            {
                return false;
            }
            else
            {
                _tasks.Add(entity);
                return true;
            }
        }

        public bool Update(Tasks entity)
        {
            bool exist = _tasks.Exists(t => t.Id.Equals(entity.Id));

            Tasks findTask = _tasks.Find(t => t.Id == entity.Id);

            if (findTask != null)
            {
                findTask = entity;
                return exist;
            }
            else
            {
                return exist;
            }
        }

        public bool Delete(Tasks entity)
        {
            bool exist = _tasks.Exists(t => t.Id.Equals(entity.Id));

            Tasks findTask = _tasks.Find(t => t.Id == entity.Id);

            if (exist)
            {
                _tasks.Remove(findTask);
                return exist;
            }
            else
            {
                return exist;
            }
        }
    }
}
