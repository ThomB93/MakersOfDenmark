using System;
using System.Net.Http;
using System.Threading.Tasks;
using MakersOfDenmarkApi;
using MakersOfDenmarkApi.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MakersOfDenmarkTests
{
    public class UnitTest1
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;
        
        public UnitTest1()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        
        
        [Fact]
        public async Task Get_WeatherForecast_success()
        {
            // Arrange
            var ILogger_mock = new Mock<ILogger<WeatherForecastController>>();
            var weatherForecastController = new WeatherForecastController(ILogger_mock.Object);
            
            
            // Act
            var response = await _client.GetAsync("/weatherforecast");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal("Hello World!", responseString);
            
        }
    }
}