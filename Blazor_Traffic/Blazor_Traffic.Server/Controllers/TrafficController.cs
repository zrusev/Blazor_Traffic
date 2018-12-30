namespace Blazor_Traffic.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Services;
    using Shared;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class TrafficController : Controller
    {
        private readonly TrafficService _trafficService;

        public TrafficController(TrafficService trafficService)
        {
            _trafficService = trafficService;
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

        [HttpGet("[action]")]
        public JsonResult GetStopsList()
        {
            string text;

            var fileStream = new FileStream("./Data/coordinates_with_linetypes.json", FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            List<Stop> items = JsonConvert.DeserializeObject<List<Stop>>(text);

            return Json(items);
        }
    }
}
