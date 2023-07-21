using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using VuelingDomain.DomainEntities;
using VuelingDomain.RepositoryContracts;
using VuelingServices.DTOs;
using VuelingServices.ServiceImplementations;

namespace BussinesTest
{
    public class ServiceTestSuite
    {
        [Fact]
        public void GetAllPassengersByDate_ReturnsEmptyList()
        {
            // Arrange
            var passengersRepositoryMock = new Mock<IPassengersRepository>();
            var baggageRepositoryMock = new Mock<IBaggageRepository>();
            var flightRepositoryMock = new Mock<IFlightRepository>();

            passengersRepositoryMock.Setup(repo => repo.GetPassengersInfo())
                .Returns(new List<Passengers>());

            baggageRepositoryMock.Setup(repo => repo.GetBaggageInfo())
                .Returns(new List<Baggages>());

            flightRepositoryMock.Setup(repo => repo.GetFlightInfo())
                .Returns(new List<Flights>());

            var service = new VuelingService(passengersRepositoryMock.Object, baggageRepositoryMock.Object, flightRepositoryMock.Object);

            // Act
            List<PassengersWithCarryOnDTO>? result = service.GetAllPassengersByDate();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllPassengersByDate_CallsAllMethodsOnce()
        {
            // Arrange
            var passengersRepositoryMock = new Mock<IPassengersRepository>();
            var baggageRepositoryMock = new Mock<IBaggageRepository>();
            var flightRepositoryMock = new Mock<IFlightRepository>();

            passengersRepositoryMock.Setup(repo => repo.GetPassengersInfo())
                .Returns(new List<Passengers>());

            baggageRepositoryMock.Setup(repo => repo.GetBaggageInfo())
                .Returns(new List<Baggages>());

            flightRepositoryMock.Setup(repo => repo.GetFlightInfo())
                .Returns(new List<Flights>());

            var service = new VuelingService(passengersRepositoryMock.Object, baggageRepositoryMock.Object, flightRepositoryMock.Object);

            // Act
            List<PassengersWithCarryOnDTO>? result = service.GetAllPassengersByDate();

            // Assert
            passengersRepositoryMock.Verify(repo => repo.GetPassengersInfo(), Times.Once);
            baggageRepositoryMock.Verify(repo => repo.GetBaggageInfo(), Times.Once);
            flightRepositoryMock.Verify(repo => repo.GetFlightInfo(), Times.Once);
        }
    }
}
