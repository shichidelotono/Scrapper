using System.Threading.Tasks;

namespace Scrapper.Api.SearchService
{
    public interface IGoogleSearchService
    {
        Task<string> GetHtmlString(string url);
    }
}