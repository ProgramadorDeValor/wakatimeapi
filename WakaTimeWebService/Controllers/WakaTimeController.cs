using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WakaTimeWebService.Data.Dtos;
using WakaTimeWebService.Data.Factories;
using WakaTimeWebService.Data.Models;
using WakaTimeWebService.Services;
using WakaTimeWebService.Utils;

namespace WakaTimeWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WakaTimeController : ControllerBase
    {

        private readonly ILogger<WakaTimeController> _logger;
        private WakaTimeService _service;

        public WakaTimeController(ILogger<WakaTimeController> logger, IConfiguration config)
        {
            _logger = logger;
            _service = new WakaTimeService(WakatimeClientHttpFactory.GetClient(config["Wakatime:Apikey"]));
        }

        [HttpGet("AllTimeSinceToday")]
        public AllTimeSinceToday GetAllTimeSinceToday()
        {
            try
            {
                var dto = new AllTimeSinceTodayDto();
                var tResponse = _service.GetAllTimeSinceToday();
                Task.WaitAll(tResponse);
                var json = JsonUtils.GetJsonFromHttpResponse(tResponse.Result);
                var result = dto.ConvertJsonToObject(json);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpGet("Stats")]
        public Stats GetStats()
        {
            try
            {
                var dto = new StatsDto();
                var tResponse = _service.GetStats(WakaTimeService.Stats.last_7_days);
                Task.WaitAll(tResponse);
                var json = JsonUtils.GetJsonFromHttpResponse(tResponse.Result);
                var result = dto.ConvertJsonToObject(json);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpGet("Projects")]
        public List<Project> GetProject()
        {
            try
            {
                var dto = new ProjectDto();
                var tResponse = _service.GetProjects();
                Task.WaitAll(tResponse);
                var json = JsonUtils.GetJsonFromHttpResponse(tResponse.Result);
                var result = dto.ConvertStringToList(json);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
