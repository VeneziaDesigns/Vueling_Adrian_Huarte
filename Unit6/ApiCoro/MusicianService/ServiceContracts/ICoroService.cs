using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusiciansManagement.DTOs;

namespace MusicianService.ServiceContracts
{
    public interface ICoroService
    {
        List<MusicianDTO> GetConcert(string date);
    }
}
