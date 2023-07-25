using Domain.DTOs.Request;

namespace Domain.ServiceContracts
{
    public interface IControlService
    {
        Task<List<PassengersByFlightDateResponse>> GetAllPassengersByDate();
        Task<TotalPassengersAndWeightFillByFlight> GetTotalWeightAndTotalBaggageWeightByDay();
        Task<List<AverageWeightByFlightResponse>> GetAverageWeightByFlight();
        Task<TotalWeightByFlightFillResponse> GetTotalWeightByBaggageType(string FlightId, string BaggageType);   
    }
}
