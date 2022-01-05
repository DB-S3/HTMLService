using Common;
using HTMLServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class IntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly TestingWebAppFactory<Startup> _client;

        public IntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory;
        }

        [Fact]
        public async Task ViewPage()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/page/viewpage/pageId");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("pageId", responseString);
            client.Dispose();
        }

        [Fact]
        public async Task Addpage()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/page/AddPage/NewPageTest");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("succes", responseString);
            client.Dispose();
        }

        [Fact]
        public async Task GetPageList()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/page/GetPageList");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("pageId", responseString);
            client.Dispose();
        }

        [Fact]
        public async Task RenamePage()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/page/RenamePage/newpagename/pageId");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("succes", responseString);
            client.Dispose();
        }

        [Fact]
        public async Task DeletePage()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/page/DeletePage/pageId");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("succes", responseString);
            client.Dispose();
        }

        //[Fact]
        //public async Task ChangePage()
        //{
        //    var client = _client.CreateClient(
        //    new WebApplicationFactoryClientOptions
        //    {
        //        AllowAutoRedirect = false
        //    });

        //    string json = JsonConvert.SerializeObject(new Page() { Name = "hehe" });
        //    StringContent data = new StringContent(json, Encoding.UTF8, "application/json");


        //     Act
        //    var response = await client.PostAsync("/page/DeletePage/pageId", data);

        //     Assert
        //    response.EnsureSuccessStatusCode();
        //    var responseString = await response.Content.ReadAsStringAsync();

        //    Assert.Contains("succes", responseString);
        //    client.Dispose();
        //}

        [Fact]
        public async Task CreateWebsite()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/website/CreateWebsite/test.com");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("succes", responseString);
            client.Dispose();
        }
    }
}
