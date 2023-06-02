using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class InfrastructureData
    {
        public Dictionary<int, int> InitializeUsers()
        {
            Dictionary<int, int> users = new Dictionary<int, int>()
            {
                { 1111, 1 },
                { 2222, 2 },
                { 3333, 3 },
                { 4444, 4 },
                { 5555, 5 },
            };
            return users;
        }
    }
}
