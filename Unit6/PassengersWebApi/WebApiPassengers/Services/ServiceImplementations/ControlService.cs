using Domain.DomainEntities;
using Domain.DomainEntities.Requests;
using Domain.DomainServices;
using Domain.RepositoryContracts;
using Services.ServiceContracts;

namespace Services.ServiceImplementations
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

        public async Task<List<PassengersByFlightWithCarryOn>> GetAllPassengersByDate()
        {
            (List<PassengersInfo> allPassengers, List<BaggagesInfo> allBaggages, List<FlightsInfo> allFlights) = await GetAllData();

            List<PassengersByFlightWithCarryOn> fillInfo = InfoToFill.GetAllPassengerByDate(allPassengers, allBaggages, allFlights);
        
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
