using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NetMesnG.Api;
using Xunit;

namespace NetMesnG.Integration.Tests
{
    public class SendTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public SendTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Theory]
        [InlineData("/send")]
        public async Task Test1(string relativePath)
        {
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(relativePath);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }
    }
}