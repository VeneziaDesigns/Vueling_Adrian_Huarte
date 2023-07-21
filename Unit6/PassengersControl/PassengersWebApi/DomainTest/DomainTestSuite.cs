using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using VuelingDomain.DomainEntities;
using VuelingDomain.DomainServices;

namespace DomainTest
{
    public class DomainTestSuite
    {
        [Fact]
        public void FilterPassengersByCarryOn_ReturnsExpectedResult()
        {
            // Arrange
            var allPassengersInfoMock = new Mock<IList<Passengers>>();
            var allBaggageInfoMock = new Mock<IList<Baggages>>();
            var allFlightsInfoMock = new Mock<IList<Flights>>();

            allPassengersInfoMock.Setup(p => p.Count)
                .Returns(2);
            allPassengersInfoMock.Setup(p => p.GetEnumerator())
                .Returns(new List<Passengers>
                {
                    new Passengers
                    { 
                        Name = "A",
                        Surname = "B",
                        PassengerId = "1", 
                        FlightId = "2",
                        Weight = 87
                    }
                }.GetEnumerator());

            allBaggageInfoMock.Setup(b => b.Count)
                .Returns(2);
            allBaggageInfoMock.Setup(b => b.GetEnumerator())
                .Returns(new List<Baggages>
                {
                new Baggages 
                    {
                        BaggageId = "3",
                        PassengerId = "1", 
                        BaggageType = "Carry-on", 
                        Weight = 8 
                    }
                }.GetEnumerator());

            allFlightsInfoMock.Setup(f => f.Count)
                .Returns(2);
            allFlightsInfoMock.Setup(f => f.GetEnumerator())
                .Returns(new List<Flights>
                {
                new Flights 
                    { 
                        FlightId = "2", 
                        Departure = "Tokyo", 
                        Arrival = "New York",
                        FlightDateWithoutHour = DateTime.Now,
                    }
                }.GetEnumerator());

            // Act
            List<PassengersWithCarryOn>? result = FilterByFlight.FilterPassengersByCarryOn(
             allPassengersInfoMock.Object.ToList(),
             allBaggageInfoMock.Object.ToList(),
             allFlightsInfoMock.Object.ToList());

             // Assert
             Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void FilterPassengersByCarryOn_ReturnsNotNull_Empty()
        {
            // Arrange
            var allPassengersInfoMock = new Mock<List<Passengers>>();
            var allBaggageInfoMock = new Mock<List<Baggages>>();
            var allFlightsInfoMock = new Mock<List<Flights>>();

            // Act
            List<PassengersWithCarryOn>? result = FilterByFlight.FilterPassengersByCarryOn(allPassengersInfoMock.Object, allBaggageInfoMock.Object, allFlightsInfoMock.Object);

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }
    }
}
