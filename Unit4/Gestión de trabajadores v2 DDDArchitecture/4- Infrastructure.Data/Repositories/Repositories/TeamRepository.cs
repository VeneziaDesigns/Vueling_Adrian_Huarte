using System;
using System.Collections.Generic;
using System.Linq;
using DomainEntities;

namespace Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly List<Team> _teams;


        public List<Team> GetAll()
        {
            return _teams;
        }

        public Team GetByName(string teamName)
        {
            return _teams.FirstOrDefault(t => t.TeamName.Equals(teamName));
        }

        public bool Insert(Team entity)
        {
            bool exist = _teams.Exists(t => t.TeamName.Equals(entity.TeamName));

            if (exist == true)
            {
                return false;
            }
            else
            {
                _teams.Add(entity);
                return true;
            }
        }

        public bool Update(Team entity)
        {
            bool exist = _teams.Exists(t => t.TeamName.Equals(entity.TeamName));

            Team findTeam = _teams.Find(t => t.TeamName == entity.TeamName);

            if (findTeam != null)
            {
                findTeam = entity;
                return exist;
            }
            else
            {
                return exist;
            }
        }

        public bool Delete(Team entity)
        {
            bool exist = _teams.Exists(t => t.TeamName.Equals(entity.TeamName));

            Team findTask = _teams.Find(t => t.TeamName == entity.TeamName);

            if (exist)
            {
                _teams.Remove(findTask);
                return exist;
            }
            else
            {
                return exist;
            }
        }
    }
}
