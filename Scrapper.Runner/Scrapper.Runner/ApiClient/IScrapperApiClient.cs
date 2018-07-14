using Scrapper.Runner.Response;

namespace Scrapper.Runner.ApiClient
{
    public interface IScrapperApiClient
    {
        PositionsResponse GetPositions(string url);
    }
}