using System;
using System.Linq;

namespace Scrapper.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var scrapperService = DependencyInjectionContainer.Instance.ScrapperService;

            while (true)
            {
                // 1. user inputs
                Console.WriteLine("Please enter search key word. e.g. facebook");
                var keyword = Console.ReadLine();

                Console.WriteLine("Please enter target key word as url or string. e.g. www.facebook.com");
                var target = Console.ReadLine();

                // 2. send request and get result
                var result = scrapperService.GetPositions($"/api/scrapper?keyword={keyword}&targeturl={target}");
                Console.WriteLine($"A request with search keyword [{keyword}] has been sent");

                // 3. display result
                if (result == null || !result.Positions.Any())
                    Console.WriteLine($"[{target}] is not found in search result");
                else
                    Console.WriteLine($"[{target}] is found in search result location positon: {string.Join(",", result.Positions)}");
            }
        }
    }
}
