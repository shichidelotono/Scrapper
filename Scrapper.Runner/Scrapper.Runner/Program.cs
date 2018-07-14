using System;
using Scrapper.Runner.ApiClient;

namespace Scrapper.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var keyword = string.Empty;
                var targetUrl = string.Empty;

                Console.WriteLine("Please enter search key word. e.g. conveyancing software");
                keyword = Console.ReadLine();

                Console.WriteLine("Please enter target url. e.g. www.smokeball.com.au");
                targetUrl = Console.ReadLine();

                // var baseUrl = "http://scrapper-api-container:5000";
                var baseUrl = "http://localhost:5000";
                Console.WriteLine(baseUrl);
                var client = new ScrapperApiClient(baseUrl);
                var result = client.GetPositions($"/api/scrapper?keyword={keyword}&targeturl={targetUrl}");

                Console.WriteLine(string.Join(",", result.Positions));
            }
        }
    }
}
