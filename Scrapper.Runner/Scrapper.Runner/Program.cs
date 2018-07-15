using System;
using Scrapper.Runner.ApiClient;
using JsonConfig;

namespace Scrapper.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // get user inputs
                var keyword = string.Empty;
                var targetUrl = string.Empty;
                Console.WriteLine("Please enter search key word. e.g. facebook");
                keyword = Console.ReadLine();
                Console.WriteLine("Please enter target key word as url or string. e.g. www.facebook.com");
                targetUrl = Console.ReadLine();

                // get scrapper web api url
                var scrapperApiEndpoint = GetApiEndpoint();

                // send request
                var client = new ScrapperApiClient(scrapperApiEndpoint);
                Console.WriteLine($"A request with search keyword [{keyword}] has been sent to [{scrapperApiEndpoint}]");
                var result = client.GetPositions($"/api/scrapper?keyword={keyword}&targeturl={targetUrl}");

                // display result
                Console.WriteLine($"[{targetUrl}] is found in search result location positon: {string.Join(",", result.Positions)}");
            }
        }

        public static string GetApiEndpoint()
        {
            return Config.Default.ApiEndpoint;
        }
    }
}
