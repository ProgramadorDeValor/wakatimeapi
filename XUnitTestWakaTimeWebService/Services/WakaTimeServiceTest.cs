using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WakaTimeWebService.Services;
using Xunit;
using XUnitTestWakaTimeWebService.Mockery;

namespace XUnitTestWakaTimeWebService.Services
{
    public class WakaTimeServiceTest
    {
        private WakaTimeService GetTestService(string expectedResponse, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var mock = new MockHttpMessageHandler(expectedResponse, statusCode);
            var http = new HttpClient(mock);
            http.BaseAddress = new Uri("http://localhost/");
            return new WakaTimeService(http);
        }

        [Fact]
        public async void CanGetAllTimeSinceToday()
        {
            var service = GetTestService("123");
            var message = await service.GetAllTimeSinceToday();
            var content  = await message.Content.ReadAsStringAsync();
            Assert.Equal("123", content);
        }

        [Fact]
        public async void CanGetStats()
        {
            var service = GetTestService("123");
            var message = await service.GetStats(WakaTimeService.Stats.last_7_days);
            var content = await message.Content.ReadAsStringAsync();
            Assert.Equal("123", content);
        }

        [Fact]
        public async void CanGetProject()
        {
            var service = GetTestService("123");
            var message = await service.GetProjects();
            var content = await message.Content.ReadAsStringAsync();
            Assert.Equal("123", content);
        }

        [Fact]
        public async void CanGetGoals()
        {
            var service = GetTestService("123");
            var message = await service.GetGoals();
            var content = await message.Content.ReadAsStringAsync();
            Assert.Equal("123", content);
        }

        [Fact]
        public async void CanGetSummary()
        {
            var startDate = DateTime.Now.AddHours(-1);
            var endDate = DateTime.Now;
            var service = GetTestService("123");
            var message = await service.GetSummaries(startDate, endDate);
            var content = await message.Content.ReadAsStringAsync();
            Assert.Equal("123", content);
        }

    }
}
