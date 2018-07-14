using System.Collections.Generic;
using System.Linq;
using AngleSharp.Parser.Html;

namespace Scrapper.Api.HtmlService
{
    public class HtmlProcessor : IHtmlProcessor
    {
        private readonly HtmlParser _htmlParser = new HtmlParser();

        public IEnumerable<int> GetSearchPositions(string htmlString, string targetUrl)
        {
            var document = _htmlParser.Parse(htmlString);
            return document.All
                .Where(doc => doc.LocalName == "div" && doc.ClassList.Contains("g"))
                .Select((elem, index) => new { index, elem.InnerHtml })
                .Where(e => e.InnerHtml.Contains(targetUrl)).Select(item => item.index);
        }
    }
}
