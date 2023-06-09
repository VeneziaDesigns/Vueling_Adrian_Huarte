using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;

namespace Services.IServices
{
    public interface ITeamServices
    {
        void RegisterNewTeam(Team team);
        List<string> ListAllTeamNames();
    }
}
