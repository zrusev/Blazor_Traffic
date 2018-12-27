namespace Blazor_Traffic.Server.Services
{
    using Shared;
    using System.Collections.Generic;
    using System.Net.Http;
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
    }
}

