using Domain.DomainEntities.Requests;

namespace Services.ServiceContracts
{
    public interface IControlService
    {
        Task<List<PassengersByFlightWithCarryOn>> GetAllPassengersByDate();
    }
}
