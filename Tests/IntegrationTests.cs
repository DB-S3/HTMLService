using HTMLServer;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class IntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        public IntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_GET_Action()
        {

            // Act
            var response = await _client.GetAsync("/page/viewpage/testId");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("", responseString);
        }
    }
}
