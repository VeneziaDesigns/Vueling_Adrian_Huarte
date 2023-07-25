using Domain.DomainEntities;
using Domain.DomainServices;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.DTOs.Request;

namespace Domain.ServiceImplementations
{
    public class ControlService : IControlService
    {
        private readonly IPassengersRepository _passenggersRepository;
        private readonly IBaggageRepository _baggageRepository;
        private readonly IFlightsRepository _flightsRepository;

        public ControlService(IPassengersRepository passenggersRepository, IBaggageRepository baggageRepository,
                                                                           IFlightsRepository flightsRepository)
        {
            _passenggersRepository = passenggersRepository;
            _baggageRepository = baggageRepository;
            _flightsRepository = flightsRepository;
        }

        public async Task<List<PassengersByFlightDateResponse>> GetAllPassengersByDate()
        {
            (List<PassengersInfo> allPassengers, List<BaggagesInfo> allBaggages, List<FlightsInfo> allFlights) = await GetAllData();

            List<PassengersByFlightDateResponse> fillInfo = InfoToFill.FillAllPassengerByDate(allPassengers, allBaggages, allFlights);

            return fillInfo;
        }

        public async Task<TotalPassengersAndWeightFillByFlight> GetTotalWeightAndTotalBaggageWeightByDay()
        {
            (List<PassengersInfo> allPassengers, List<BaggagesInfo> allBaggages, List<FlightsInfo> allFlights) = await GetAllData();

            TotalPassengersAndWeightFillByFlight fillInfo = InfoToFill.FillTotalWeightAndTotalBaggageWeightByDay(allPassengers, allBaggages, allFlights);

            return fillInfo;
        }

        public async Task<List<AverageWeightByFlightResponse>> GetAverageWeightByFlight()
        {
            (List<PassengersInfo> allPassengers, List<BaggagesInfo> allBaggages, List<FlightsInfo> allFlights) = await GetAllData();

            List<AverageWeightByFlightResponse> fillInfo = InfoToFill.FillAverageWeightByFlight(allPassengers, allBaggages, allFlights);

            return fillInfo;
        }

        public async Task<TotalWeightByFlightFillResponse> GetTotalWeightByBaggageType(string FlightId, string BaggageType)
        {
            (List<PassengersInfo> allPassengers, List<BaggagesInfo> allBaggages, List<FlightsInfo> allFlights) = await GetAllData();

            TotalWeightByFlightFillResponse fillInfo = InfoToFill.FillTotalWeightByBaggageType(allPassengers, allBaggages, FlightId, BaggageType);

            return fillInfo;
        }

        private async Task<(List<PassengersInfo>, List<BaggagesInfo>, List<FlightsInfo>)> GetAllData()
        {
            List<PassengersInfo> allPassengers = await _passenggersRepository.GetPassengersInfo();
            List<BaggagesInfo> allBaggages = await _baggageRepository.GetBaggagesInfo();
            List<FlightsInfo> allFlights = await _flightsRepository.GetFlightsInfo();

            return (allPassengers, allBaggages, allFlights);
        }
    }
}
