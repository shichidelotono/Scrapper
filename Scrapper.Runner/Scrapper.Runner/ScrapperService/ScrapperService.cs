using Scrapper.Runner.ApiClient;
using Scrapper.Runner.ConfigService;
using Scrapper.Runner.ScrapperService.Dto;

namespace Scrapper.Runner.ScrapperService
{
    public class ScrapperService : IScrapperService
    {
        private readonly IApiClientHandler _handler;
        private readonly IConfigService _configService;

        public ScrapperService(IApiClientHandler handler, IConfigService configService)
        {
            _handler = handler;
            _configService = configService;
        }

        public PositionsDto GetPositions(string url)
        {
            _handler.ConfigureApiClient(_configService.GetApiEndpoint());

            var result = _handler.Get(url);

            return new PositionsDto(_handler.GetPositions(result).Positions);
        }
    }
}
