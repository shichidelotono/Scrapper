using Scrapper.Runner.Response;

namespace Scrapper.Runner.ApiClient
{
    public interface IApiClientHandler
    {
        void ConfigureApiClient(string baseUrl);
        string Get(string url);
        PositionsResponse GetPositions(string apiResult);
    }
}