using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Scrapper.Api.SearchService
{
    public class GoogleSearchService : IGoogleSearchService
    {
        private readonly HttpClient _client;

        public GoogleSearchService(string baseUrl)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<string> GetHtmlString(string url)
        {
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"An error occured while making a request to {url}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
