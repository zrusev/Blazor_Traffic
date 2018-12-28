namespace Blazor_Traffic.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class TrafficController : Controller
    {
        private readonly TrafficService _trafficService;

        public TrafficController(TrafficService trafficService)
        {
            _trafficService = trafficService;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Station>> All()
        {
            return await _trafficService.GetAllStations("/v1/metro/all");
        }

        [HttpGet("[action]/{id}")]
        public async Task<StationTimes> ById(int id)
        {
            return await _trafficService.GetStationById($"/v1/metro/times/{id}");
        }
    }
}
