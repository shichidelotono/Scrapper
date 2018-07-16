using System;
using System.Net.Http;
using Newtonsoft.Json;
using Scrapper.Runner.Response;

namespace Scrapper.Runner.ApiClient
{
    public class ApiClientHandler : IApiClientHandler
    {
        private readonly HttpClient _client;

        public ApiClientHandler(HttpClient client)
        {
            _client = client;
        }

        public void ConfigureApiClient(string baseUrl)
        {
            if (_client.BaseAddress == null || string.IsNullOrWhiteSpace(_client.BaseAddress.ToString()))
                _client.BaseAddress = new Uri(baseUrl);
        }

        public string Get(string url)
        {
            var response = _client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"An error occured while making a request to {url}");

            return response.Content.ReadAsStringAsync().Result;
        }

        public PositionsResponse GetPositions(string apiResult)
        {
            return JsonConvert.DeserializeObject<PositionsResponse>(apiResult);
        }
    }
}
