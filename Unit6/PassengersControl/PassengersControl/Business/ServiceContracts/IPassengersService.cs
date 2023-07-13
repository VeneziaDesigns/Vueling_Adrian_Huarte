using Domain.DomainEntities;
using DTOs.DTOs;

namespace Business.ServiceContracts
{
    public interface IPassengersService
    {
        List<PassengersWithCarryOnDTO> GetAllInformation();
    }
}
