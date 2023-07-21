using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using SpatialCoordinates.Controllers;
using SpatialCoordinatesDomain;
using SpatialCoordinatesDomain.CustomExceptions;
using SpatialCoordinatesDomain.IContracts;
using SpatialCoordinatesDomain.ServiceImplementation;
using SpatialCoordinatesInfrastructure.Data.CoordinatesRepository;
using Xunit;

namespace SpatialCoordinates.Infrastructure.Tests.WebApi
{
    public class CoordinatesControllerTestSuite
    {
        #region PrivateControllerInitializers
        private CoordinatesController InitController()
        {
            CoordinatesController controller =
                new CoordinatesController(
                    new CoordinatesServices(
                        new CoordinatesRepository()));

            return controller;
        }

        private CoordinatesController InitControllerWithMockedService()
        {
            Mock<ICoordinateService> serviceMock = new Mock<ICoordinateService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Coordinates>()));

            ICoordinateService mockedService = serviceMock.Object;

            return new CoordinatesController(mockedService);
        }
        #endregion

        #region Register action tests
        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CoordinatesController controller = InitController();
            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CoordinatesController controller = InitControllerWithMockedService();
            List<decimal> values = new List<decimal> { 1, 2, 3 };

            // Act
            IHttpActionResult result = controller.Register(values);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputSizeZero_ReturnsBadRequestResult()
        {
            // Arrange
            CoordinatesController controller = InitControllerWithMockedService();
            List<decimal> values = new List<decimal>();

            // Act
            IHttpActionResult result = controller.Register(values);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputSizeMoreThanThree_ReturnsBadRequestResult()
        {
            // Arrange
            CoordinatesController controller = InitControllerWithMockedService();
            List<decimal> values = new List<decimal> { 0, 0, 0, 0, 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_InvalidCoordXExceptionCaught_ReturnsBadRequest()
        {
            // Arrange
            Mock<ICoordinateService> serviceMock = new Mock<ICoordinateService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Coordinates>())).Throws<InvalidCoordXException>();

            ICoordinateService mockedService = serviceMock.Object;

            CoordinatesController controller = new CoordinatesController(mockedService);

            List<decimal> values = new List<decimal> { 9, 8, 7 };

            // Act
            IHttpActionResult result = controller.Register(values);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_CannotSaveDataExceptionCaught_ReturnsBadRequest()
        {
            // Arrange
            Mock<ICoordinateService> serviceMock = new Mock<ICoordinateService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Coordinates>())).Throws<CanNotSaveDataException>();

            ICoordinateService mockedService = serviceMock.Object;

            CoordinatesController controller = new CoordinatesController(mockedService);

            List<decimal> values = new List<decimal> { 9, 8, 7 };

            // Act
            IHttpActionResult result = controller.Register(values);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }
        #endregion
    }
}
