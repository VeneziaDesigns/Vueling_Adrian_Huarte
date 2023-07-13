using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using MusicianDomain.CustomExceptions;
using MusicianDomain.DomainEntities;
using MusicianRepository.DataModels;
using MusicianRepository.RepositoryImplementations;

namespace Repository.ApiCoro.Test
{
    public class MusicosRepositoryTestSuite
    {

        [Fact]
        public void GetMusicians_ReturnsListOfMusicians()
        {
            // Arrange
            
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(config => config.GetSection("ApiSettings").GetSection("MusicosUrl").Value);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();

            var musiciansFromJson = new List<MusiciansInfoFromJson>();

            var jsonContent = JsonSerializer.Serialize(musiciansFromJson);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonContent)
            };

            httpClientMock.Setup(client => client.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClientMock.Object);

            var musicosRepository = new MusicosRepository(configurationMock.Object);

            // Act
            var result = musicosRepository.GetMusicians();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Musicos>>(result);
            Assert.NotEqual(musiciansFromJson.Count, result.Count);
            Assert.Empty(musiciansFromJson);
        }

        [Fact]
        public void GetMusicians_ReturnsResponseStatusCodeNotFound_ThrowException()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(config => config.GetSection("ApiSettings").GetSection("MusicosUrl").Value)
                .Returns("https://urlfalsa/123");

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();

            var musiciansFromJson = new List<MusiciansInfoFromJson>();

            var jsonContent = JsonSerializer.Serialize(musiciansFromJson);

            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(jsonContent)
            };

            httpClientMock.Setup(client => client.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClientMock.Object);

            var musicosRepository = new MusicosRepository(configurationMock.Object);

            // Act
            var exception = Assert.Throws<ResourceNotAvailableException>(() => musicosRepository.GetMusicians());

            // Assert
            Assert.Equal("The resource is not available", exception.Message);
        }
    }
}
