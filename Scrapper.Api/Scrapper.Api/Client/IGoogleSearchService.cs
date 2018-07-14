using System.Threading.Tasks;

namespace Scrapper.Api.Client
{
    public interface IGoogleSearchService
    {
        Task<string> GetHtmlString(string url);
    }
}