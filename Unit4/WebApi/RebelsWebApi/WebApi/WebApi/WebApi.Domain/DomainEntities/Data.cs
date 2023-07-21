using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.DomainEntities
{
    public class Data
    {

        public string RebelName { get; set; }
        public string NombreP { get; set; }
        public DateTime PlanetName { get; set; }

        public Data()
        {
        }
    }
}
