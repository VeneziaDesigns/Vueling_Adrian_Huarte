using CrudServices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TestSQLServer.Controllers;
using TestSQLServer.DomainEntities;

namespace CrudDDDTestSuite.ControllerTest
{
    public class ControllerTestSuite
    {
        #region GetAllUnitTest
        [Fact]
        public void GetAll_WithUsers_ReturnsOkResult_CallMethodTIemesOnce()
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            var users = new List<UserWorkers>
            {
                new UserWorkers { Name = "Jack", Surname = "Sparrow", Salary = 1000, YearsOfExperience = 2 },
                new UserWorkers { Name = "John", Surname = "Smith", Salary = 1500, YearsOfExperience = 4 }
            };

            mockServices.Setup(s => s.GetAllUsersService()).Returns(users);

            WebApiCrudController controller = new(mockLogger.Object, mockServices.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsType<List<UserWorkers>>(okResult.Value);
            Assert.Equal(users.Count, returnedUsers.Count);
            mockServices.Verify(s => s.GetAllUsersService(), Times.Once);
        }

        [Fact]
        public void GetAll_WithoutUsers_ReturnsBadRequest()
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            List<UserWorkers>? users = new();

            mockServices.Setup(s => s.GetAllUsersService()).Returns(users);

            WebApiCrudController controller = new(mockLogger.Object, mockServices.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("No users registered in the system.", badRequestResult.Value);
            Assert.Equal(0, users?.Count());
            mockServices.Verify(s => s.GetAllUsersService(), Times.Once);
        }

        [Fact]
        public void GetAll_ExceptionOccurs_ReturnsBadRequest()
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            mockServices.Setup(s => s.GetAllUsersService()).Throws(new Exception("Database connection error"));

            WebApiCrudController controller = new(mockLogger.Object, mockServices.Object);
            // Act
            var result = controller.GetAll();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Unexpected error occurred: Database connection error", badRequestResult.Value);
            mockServices.Verify(s => s.GetAllUsersService(), Times.Once);
        }
        #endregion

        #region GetByNameUnitTest
        [Fact]
        public void Get_WithValidNameAndSurname_ReturnsUser()
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            string name = "John";
            string surname = "Wick";

            UserWorkers userFromDb = new()
            {
                Name = name,
                Surname = surname,
                Salary = 5000,
                YearsOfExperience = 5
            };

            mockServices.Setup(s => s.GetByNameService(It.IsAny<UserWorkers>())).Returns(userFromDb);

            WebApiCrudController controller = new WebApiCrudController(mockLogger.Object, mockServices.Object);

            // Act
            var result = controller.Get(name, surname);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(userFromDb, okResult.Value);
            mockServices.Verify(s => s.GetByNameService(It.IsAny<UserWorkers>()), Times.Once);
        }

        [Theory]
        [InlineData("", "Porras")]
        [InlineData("Paco", "")]
        [InlineData("", "")]
        public void Get_WithInvalidNameOrSurname_ReturnsBadRequest(string name, string surname)
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            WebApiCrudController controller = new(mockLogger.Object, mockServices.Object);

            // Act
            var result = controller.Get(name, surname);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Some of the data entered is not valid.", badRequestResult.Value);
            mockServices.Verify(s => s.GetByNameService(It.IsAny<UserWorkers>()), Times.Never);
        }

        [Fact]
        public void Get_UserNotFound_ReturnsBadRequest()
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            string name = "John";
            string surname = "Wick";

            mockServices.Setup(s => s.GetByNameService(It.IsAny<UserWorkers>())).Returns((UserWorkers?)null);

            WebApiCrudController controller = new(mockLogger.Object, mockServices.Object);

            // Act
            var result = controller.Get(name, surname);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("User not found", badRequestResult.Value);
            mockServices.Verify(s => s.GetByNameService(It.IsAny<UserWorkers>()), Times.Once);
        }

        [Fact]
        public void Get_ExceptionOccurs_ReturnsBadRequestWithErrorMessage()
        {
            // Arrange
            var mockServices = new Mock<ICrudService>();
            var mockLogger = new Mock<ILogger<WebApiCrudController>>();

            string name = "John";
            string surname = "Wick";

            mockServices.Setup(s => s.GetByNameService(It.IsAny<UserWorkers>())).Throws(new Exception("Some error"));

            WebApiCrudController controller = new(mockLogger.Object, mockServices.Object);

            // Act
            var result = controller.Get(name, surname);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Unexpected error occurred: Some error", badRequestResult.Value);
            mockServices.Verify(s => s.GetByNameService(It.IsAny<UserWorkers>()), Times.Once);
        }
        #endregion
    }
}
