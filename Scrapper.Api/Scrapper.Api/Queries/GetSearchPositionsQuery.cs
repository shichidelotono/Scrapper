using System.Collections.Generic;
using MediatR;

namespace Scrapper.Api.Queries
{
    public class GetSearchPositionsQuery : IRequest<List<int>>
    {
        public string Keyword { get; }
        public string TargetUrl { get; }

        public GetSearchPositionsQuery(string keyword, string targetUrl)
        {
            Keyword = keyword;
            TargetUrl = targetUrl;
        }
    }
}
