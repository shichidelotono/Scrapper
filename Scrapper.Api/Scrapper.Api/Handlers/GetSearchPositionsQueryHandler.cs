using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scrapper.Api.Client;
using Scrapper.Api.HtmlService;
using Scrapper.Api.Queries;

namespace Scrapper.Api.Handlers
{
    public class GetSearchPositionsQueryHandler : IRequestHandler<GetSearchPositionsQuery, List<int>>
    {
        private readonly IGoogleSearchService _searchService;
        private readonly IHtmlProcessor _htmlProcessor;

        public GetSearchPositionsQueryHandler(IGoogleSearchService searchService, IHtmlProcessor htmlProcessor)
        {
            _searchService = searchService;
            _htmlProcessor = htmlProcessor;
        }

        public async Task<List<int>> Handle(GetSearchPositionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _searchService.GetHtmlString($"/search?num=100&q={request.Keyword}");

            var result = _htmlProcessor.GetSearchPositions(response, request.TargetUrl).ToList();

            return result;
        }
    }
}
