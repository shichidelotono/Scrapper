using System.Collections.Generic;

namespace Scrapper.Api.HtmlService
{
    public interface IHtmlProcessor
    {
        IEnumerable<int> GetSearchPositions(string htmlString, string targetUrl);
    }
}