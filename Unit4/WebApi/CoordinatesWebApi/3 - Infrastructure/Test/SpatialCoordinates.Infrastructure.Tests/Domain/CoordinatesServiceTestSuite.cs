using System;
using System.Linq;
using SpatialCoordinatesDomain;
using SpatialCoordinatesDomain.ServiceImplementation;
using SpatialCoordinatesInfrastructure.Data.CoordinatesRepository;
using Xunit;

namespace SpatialCoordinates.Infrastructure.Tests
{
    public class CoordinatesServiceTestSuite
    {
        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsVoid()
        {
            // Arrange
            CoordinatesServices service = new CoordinatesServices(
                new CoordinatesRepository());

            Coordinates input = new Coordinates
            {
                coordX = 1,
                coordY = 7,
                coordZ = 5
            };

            // Act
            var exception = Record.Exception(() => service.Register(input));

            // Assert
            Assert.Null(exception);
        }
    }
}
