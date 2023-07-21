using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using DataDomain.CustomExceptions;
using DataDomain.DomainEntities;
using DataDomain.ServiceContracts;
using DataDomain.ServiceImplementation;
using DataInfrastructure;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace Data.Infrastructure.Tests.WebApi
{
    public class ControllerTestSuite
    {
        #region PrivateControllerInitializers
        private DataController InitController()
        {
            DataController controller =
                new DataController(
                    new DataServices(
                        new DataRepository()));

            return controller;
        }

        private DataController InitControllerWithMockedService()
        {
            Mock<IDataService> serviceMock = new Mock<IDataService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Datos>()));

            IDataService mockedService = serviceMock.Object;

            return new DataController(mockedService);
        }
        #endregion

        #region GetStrings action tests
        [Fact]
        public void IntegrationTest_GetStrings_InputValid_ReturnsOkResult()
        {
            // Arrange
            DataController controller = InitController();
            List<string> values = new List<string> { "red", "69", "Paco" };

            // Act
            IHttpActionResult result = controller.GetStrings(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_GetStrings_InputValid_ReturnsOkResult()
        {
            // Arrange
            DataController controller = InitControllerWithMockedService();
            List<string> values = new List<string> { "Green", "58", "Pedrito" };

            // Act
            IHttpActionResult result = controller.GetStrings(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_GetStrings_InputSizeZero_ReturnsBadRequestResult()
        {
            // Arrange
            DataController controller = InitControllerWithMockedService();
            List<string> values = new List<string>();

            // Act
            IHttpActionResult result = controller.GetStrings(values);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_GetStrings_InputSizeMoreThanThree_ReturnsBadRequestResult()
        {
            // Arrange
            DataController controller = InitControllerWithMockedService();
            List<string> values = new List<string> { "Green", "58", "Pedrito", "85", "Jacinto" };

            // Act
            IHttpActionResult result = controller.GetStrings(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_GetStrings_InputValid_ReturnsInvalidColourStringException()
        {
            // Arrange
            Mock<IDataService> serviceMock = new Mock<IDataService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Datos>())).Throws<InvalidColourStringException>();

            IDataService mockedService = serviceMock.Object;

            DataController controller = new DataController(mockedService);

            List<string> values = new List<string> { "Purple", "58", "Manolo" };

            // Act & Assert
            Assert.Throws<InvalidColourStringException>(() => controller.GetStrings(values));
        }

        [Fact]
        public void UnitTest_GetStrings_InputValid_ReturnsInvalidParsingStringException()
        {
            // Arrange
            Mock<IDataService> serviceMock = new Mock<IDataService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Datos>())).Throws<InvalidParsingStringException>();

            IDataService mockedService = serviceMock.Object;

            DataController controller = new DataController(mockedService);

            List<string> values = new List<string> { "blue", "Stelio", "Manolo" };

            // Act & Assert
            Assert.Throws<InvalidParsingStringException>(() => controller.GetStrings(values));
        }
        #endregion
    }
}
