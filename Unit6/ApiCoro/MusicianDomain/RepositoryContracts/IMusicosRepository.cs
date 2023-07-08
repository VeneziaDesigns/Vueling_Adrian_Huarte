﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicianDomain.DomainEntities;

namespace MusicianDomain.RepositoryContracts
{
    public interface IMusicosRepository
    {
        List<Musicos>? GetMusicians();
    }
}
