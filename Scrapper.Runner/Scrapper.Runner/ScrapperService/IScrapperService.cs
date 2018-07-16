using Scrapper.Runner.ScrapperService.Dto;

namespace Scrapper.Runner.ScrapperService
{
    public interface IScrapperService
    {
        PositionsDto GetPositions(string url);
    }
}