using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingServices.DTOs;

namespace VuelingServices.ServiceContracts
{
    public interface IVuelingService
    {
        List<PassengersWithCarryOnDTO>? GetAllPassengersByDate();
    }
}
