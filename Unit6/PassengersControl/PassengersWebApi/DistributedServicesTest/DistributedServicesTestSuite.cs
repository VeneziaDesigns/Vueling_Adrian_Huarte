using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiVueling.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VuelingServices.DTOs;
using VuelingServices.ServiceContracts;

namespace DistributedServicesTest
{
    public class DistributedServicesTestSuite
    {
        [Fact]
        public void GetAllPassengersByDate_ReturnSuccessfully()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PassengersController>>();
            var serviceMock = new Mock<IVuelingService>();
            var expectedPassengers = new List<PassengersWithCarryOnDTO>();
            serviceMock.Setup(service => service.GetAllPassengersByDate()).Returns(expectedPassengers);
            var controller = new PassengersController(loggerMock.Object, serviceMock.Object);

            // Act
            var result = controller.GetAllPassengersByDate();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultPassengers = Assert.IsAssignableFrom<List<PassengersWithCarryOnDTO>>(okResult.Value);
            Assert.Equal(expectedPassengers, resultPassengers);
        }

        [Fact]
        public void GetAllPassengersByDate_ReturnException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PassengersController>>();
            var serviceMock = new Mock<IVuelingService>();
            var exceptionMessage = "Error al obtener los pasajeros";
            serviceMock.Setup(service => service.GetAllPassengersByDate()).Throws(new Exception(exceptionMessage));
            var controller = new PassengersController(loggerMock.Object, serviceMock.Object);

            // Act
            var result = controller.GetAllPassengersByDate();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(exceptionMessage, badRequestResult.Value);
        }
    }
}
