using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MusicianDomain.DomainEntities;
using MusicianDomain.RepositoryContracts;
using MusicianService.ServiceImplementations;
using MusiciansManagement.DTOs;

namespace Business.ApiCoro.Test
{
    public class ServiceTestSuite
    {
        [Fact]
        public void GetConcert_InputEmptyMusiciansList_ReturnsEmptyListMusicianDTO()
        {
            // Arrange
            var conciertoRepositoryMock = new Mock<IConciertoRepository>();
            var musicosRepositoryMock = new Mock<IMusicosRepository>();
            var diasOcupadosRepositoryMock = new Mock<IDiasOcupadosRepository>();
            var cacheRepositoryMock = new Mock<ICacheRepository>();

            var coroService = new CoroService(conciertoRepositoryMock.Object, musicosRepositoryMock.Object,
                diasOcupadosRepositoryMock.Object, cacheRepositoryMock.Object);

            var musicians = new List<Musicos>();
            var date = "20230711";

            musicosRepositoryMock.Setup(mock => mock.GetMusicians())
                .Returns(musicians);

            diasOcupadosRepositoryMock.Setup(mock => mock.GetFreeDays(musicians, date))
                .Returns(new List<Musicos>());

            conciertoRepositoryMock.Setup(mock => mock.GetTypes())
                .Returns(new List<MusicianNeedForMeetingInfo>());

            // Act
            var result = coroService.GetConcert(date);

            // Assert
            Assert.NotNull(result); 
            Assert.IsType<List<MusicianDTO>>(result);
            Assert.Empty(result); 
        }

        [Fact]
        public void GetConcert_InputMusiciansList_ReturnsListMusicianDTO()
        {
            // Arrange
            var conciertoRepositoryMock = new Mock<IConciertoRepository>();
            var musicosRepositoryMock = new Mock<IMusicosRepository>();
            var diasOcupadosRepositoryMock = new Mock<IDiasOcupadosRepository>();
            var cacheRepositoryMock = new Mock<ICacheRepository>();

            var coroService = new CoroService(conciertoRepositoryMock.Object, musicosRepositoryMock.Object,
                diasOcupadosRepositoryMock.Object, cacheRepositoryMock.Object);

            List<Musicos> musicians = new();
            string date = "20230711";

            musicosRepositoryMock.Setup(mock => mock.GetMusicians())
                .Returns(musicians);

            diasOcupadosRepositoryMock.Setup(mock => mock.GetFreeDays(musicians, date))
                .Returns(new List<Musicos>());

            conciertoRepositoryMock.Setup(mock => mock.GetTypes())
                .Returns(new List<MusicianNeedForMeetingInfo>());

            // Act
            List<MusicianDTO> result = new()
            {
                new MusicianDTO
                {
                    Name = "Pedro",
                    Role = "Bajo",
                }
            };

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MusicianDTO>>(result);
            Assert.Single(result);
        }

        [Fact]
        public void GetConcert_CacheNull_CallsThreeMethodsOnceTime()
        {
            // Arrange
            var conciertoRepositoryMock = new Mock<IConciertoRepository>();
            var musicosRepositoryMock = new Mock<IMusicosRepository>();
            var diasOcupadosRepositoryMock = new Mock<IDiasOcupadosRepository>();
            var cacheRepositoryMock = new Mock<ICacheRepository>();

            var coroService = new CoroService(conciertoRepositoryMock.Object, musicosRepositoryMock.Object,
                diasOcupadosRepositoryMock.Object, cacheRepositoryMock.Object);

            var musicians = new List<Musicos>();
            var date = "20230711";

            cacheRepositoryMock.Setup(mock => mock.GetCache<List<Musicos>>("musicians"))
                .Returns((List<Musicos>?)null);

            musicosRepositoryMock.Setup(mock => mock.GetMusicians())
                .Returns(musicians);

            diasOcupadosRepositoryMock.Setup(mock => mock.GetFreeDays(musicians, date))
                .Returns(new List<Musicos>());

            conciertoRepositoryMock.Setup(mock => mock.GetTypes())
                .Returns(new List<MusicianNeedForMeetingInfo>());

            // Act
            var result = coroService.GetConcert(date);

            // Assert
            musicosRepositoryMock.Verify(mock => mock.GetMusicians(), Times.Once);
            diasOcupadosRepositoryMock.Verify(mock => mock.GetFreeDays(musicians, date), Times.Once);
            conciertoRepositoryMock.Verify(mock => mock.GetTypes(), Times.Once);
        }

        [Fact]
        public void GetConcert_CacheNotNull_CallsTwoMethodsOnce_OneMethodNever()
        {
            // Arrange
            var conciertoRepositoryMock = new Mock<IConciertoRepository>();
            var musicosRepositoryMock = new Mock<IMusicosRepository>();
            var diasOcupadosRepositoryMock = new Mock<IDiasOcupadosRepository>();
            var cacheRepositoryMock = new Mock<ICacheRepository>();

            var coroService = new CoroService(conciertoRepositoryMock.Object, musicosRepositoryMock.Object,
                diasOcupadosRepositoryMock.Object, cacheRepositoryMock.Object);

            var musicians = new List<Musicos>()
            {
                new Musicos
                {
                    Nombre = "Pedro",
                    Categorias = { "Alto", "Bajo" },
                    Fechas = { "20230711", "20230116" }
                }
            };

            var date = "20230711";

            cacheRepositoryMock.Setup(mock => mock.GetCache<List<Musicos>>("musicians"))
                .Returns(musicians); 
                

            musicosRepositoryMock.Setup(mock => mock.GetMusicians())
                .Returns(musicians);

            diasOcupadosRepositoryMock.Setup(mock => mock.GetFreeDays(musicians, date))
                .Returns(new List<Musicos>());

            conciertoRepositoryMock.Setup(mock => mock.GetTypes())
                .Returns(new List<MusicianNeedForMeetingInfo>());

            // Act
            var result = coroService.GetConcert(date);

            // Assert
            musicosRepositoryMock.Verify(mock => mock.GetMusicians(), Times.Never);
            diasOcupadosRepositoryMock.Verify(mock => mock.GetFreeDays(musicians, date), Times.Once);
            conciertoRepositoryMock.Verify(mock => mock.GetTypes(), Times.Once);
        }
    }
}
