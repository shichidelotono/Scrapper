using System;
using System.Net.Http;
using Newtonsoft.Json;
using Scrapper.Runner.Response;

namespace Scrapper.Runner.ApiClient
{
    public class ScrapperApiClient : IScrapperApiClient
    {
        private readonly HttpClient _client;

        public ScrapperApiClient(string baseUrl)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public PositionsResponse GetPositions(string url)
        {
            var response = _client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode) throw new HttpRequestException($"An error occured while making a request to {url}");

            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PositionsResponse>(responseString);
        }
    }
}
