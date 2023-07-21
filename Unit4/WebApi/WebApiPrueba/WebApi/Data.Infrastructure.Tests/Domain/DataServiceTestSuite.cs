using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDomain.DomainEntities;
using DataDomain.RepositoryContracts;
using DataDomain.ServiceImplementation;
using Moq;
using Xunit;

namespace Data.Infrastructure.Tests.Domain
{
    public class DataServiceTestSuite
    {
        [Fact]
        public void Register_ValidStrings_CallsInsertOnRepository()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository>();
            var stringsService = new DataServices(mockRepository.Object);

            var strings = new Datos
            {
                Colour = "Red",
                IntParseable = "12",
                Free = "Yes",
                Date = DateTime.Now,
            };

            // Act
            stringsService.Register(strings);

            // Assert
            mockRepository.Verify(r => r.Insert(strings), Times.Once);
        }
    }
}
