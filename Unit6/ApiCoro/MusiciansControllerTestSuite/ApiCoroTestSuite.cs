using ApiCoro.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MusicianDomain.CustomExceptions;
using MusicianService.ServiceContracts;
using MusiciansManagement.DTOs;

namespace ApiCoro.WebAPI.Test
{
    public class ApiCoroTestSuite
    {
        [Fact]
        public void GetConcert_ValidConcertDate_ReturnsOkResult()
        {
            // Arrange
            string validConcertDate = "2023-07-15";
            var serviceMock = new Mock<ICoroService>();
            serviceMock.Setup(s => s.GetConcert(validConcertDate))
                .Returns(new List<MusicianDTO>()
                {
                    new MusicianDTO()
                    {
                        Name = "Pedro", 
                        Role = "Bajo"
                    },
                    new MusicianDTO()
                    {
                        Name = "Pablo",
                        Role = "Tenor"
                    }
                });

            var loggerMock = new Mock<ILogger<MusiciansController>>();

            var controller = new MusiciansController(serviceMock.Object, loggerMock.Object);

            // Act
            var result = controller.GetConcert(validConcertDate);

            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(result);
            var musiciansToConcert = Assert.IsAssignableFrom<List<MusicianDTO>>(OkResult.Value);
            Assert.Equal(2, musiciansToConcert.Count);
        }

        [Fact]
        public void GetConcert_NoMusiciansAvailable_ThrowsResourceNotAvailableException()
        {
            // Arrange
            string concertDate = "2023-07-15";
            var serviceMock = new Mock<ICoroService>();
            serviceMock.Setup(s => s.GetConcert(concertDate))
                .Throws(new ResourceNotAvailableException("The resource is not available"));

            var loggerMock = new Mock<ILogger<MusiciansController>>();

            var controller = new MusiciansController(serviceMock.Object, loggerMock.Object);

            // Act
            var result = controller.GetConcert(concertDate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("The resource is not available", (result as BadRequestObjectResult)?.Value);
        }

        [Fact]
        public void GetConcert_GenericException_ReturnsBadRequest()
        {
            // Arrange
            string? concertDate = null;
            var serviceMock = new Mock<ICoroService>();
            serviceMock.Setup(s => s.GetConcert(concertDate))
                .Throws(new Exception("Some error occurred."));

            var loggerMock = new Mock<ILogger<MusiciansController>>();

            var controller = new MusiciansController(serviceMock.Object, loggerMock.Object);

            // Act
            var result = controller.GetConcert(concertDate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Something went wrong", (result as BadRequestObjectResult)?.Value);
        }

    }
}
