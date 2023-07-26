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
        private readonly ICacheRepository _cacheRepository;

        public ControlService(IPassengersRepository passenggersRepository, IBaggageRepository baggageRepository,
                                        IFlightsRepository flightsRepository, ICacheRepository cacheRepository)
        {
            _passenggersRepository = passenggersRepository;
            _baggageRepository = baggageRepository;
            _flightsRepository = flightsRepository;
            _cacheRepository = cacheRepository;
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
            #region Get/CachingPassengersRepository
            List<PassengersInfo>? allPassengers = _cacheRepository.GetCache<List<PassengersInfo>>("passengers");

            if (allPassengers == null)
            {
                allPassengers = await _passenggersRepository.GetPassengersInfo();

                _cacheRepository.SetCache("passengers", allPassengers);
            }
            #endregion

            #region Get/CachingBaggagesRepository
            List<BaggagesInfo>? allBaggages = _cacheRepository.GetCache<List<BaggagesInfo>>("baggages");

            if (allBaggages == null)
            {
                allBaggages = await _baggageRepository.GetBaggagesInfo();

                _cacheRepository.SetCache("baggages", allBaggages);
            }
            #endregion

            #region Get/CachingFlightsRepository
            List<FlightsInfo>? allFlights = _cacheRepository.GetCache<List<FlightsInfo>>("flights");

            if (allFlights == null)
            {
                allFlights = await _flightsRepository.GetFlightsInfo();

                _cacheRepository.SetCache("flights", allFlights);
            } 
            #endregion

            return (allPassengers, allBaggages, allFlights);
        }
    }
}
