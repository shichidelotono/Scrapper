using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Scrapper.Runner.ApiClient;
using Scrapper.Runner.ConfigService;
using Scrapper.Runner.ScrapperService;

namespace Scrapper.Runner
{
    public class DependencyInjectionContainer
    {
        private static DependencyInjectionContainer _instance;

        private DependencyInjectionContainer()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IConfigService, ConfigService.ConfigService>()
                .AddSingleton<IApiClientHandler>(provider => new ApiClientHandler(new HttpClient()))
                .AddSingleton<IScrapperService, ScrapperService.ScrapperService>()
                .BuildServiceProvider();

            ScrapperService = serviceProvider.GetService<IScrapperService>();
        }

        public IScrapperService ScrapperService { get; set; }

        public static DependencyInjectionContainer Instance => _instance ?? (_instance = new DependencyInjectionContainer());
    }
}
