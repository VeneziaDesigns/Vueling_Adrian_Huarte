using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianDomain.DomainEntities
{
    public class Musicos
    {
        public string? Nombre { get; set; }
        public List<string>? Categorias { get; set; } = new List<string>();
        public List<string>? Fechas { get; set; } = new List<string>();
    }
}
