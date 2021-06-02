using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using NetMesnG.Api;
using Xunit;

namespace NetMesnG.Integration.Tests
{
    public class KeepAliveTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public KeepAliveTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/keep_alive")]
        public async Task KeepAliveSuccess(string relativePath)
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(relativePath);
            var contentType = response?.Content?.Headers?.ContentType?.ToString();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", contentType);
        }
    }
}