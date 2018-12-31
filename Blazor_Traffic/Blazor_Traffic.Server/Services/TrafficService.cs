namespace Blazor_Traffic.Server.Services
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Shared;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class TrafficService
    {
        private const string BaseEndpoint = "http://drone.sumc.bg/api";

        private HttpClient Client { get; }

        public TrafficService(HttpClient client)
        {
            this.Client = client;
        }

        public async Task<IEnumerable<Station>> GetAllStations(string url)
        {
            var response = await this.Client.GetAsync(BaseEndpoint + url);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<Station>>();

            return result;
        }

        public async Task<StationTimes> GetStationById(string url)
        {
            var response = await this.Client.GetAsync(BaseEndpoint + url);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<StationTimes>(result);
        }

        public async Task<IEnumerable<StopTimes>> GetStationTiming(string url, StopCodeId stopObj)
        {
            var serializerSettings = new JsonSerializerSettings();

            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            string json = JsonConvert.SerializeObject(stopObj, serializerSettings);

            StringContent queryString = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this.Client.PostAsync(BaseEndpoint + url, queryString);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<StopTimes>>();

            return result;
        }
    }
}