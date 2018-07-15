using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Scrapper.Api.AppSettings;
using Scrapper.Api.SearchService;
using Scrapper.Api.HtmlService;
using Scrapper.Api.Queries;

namespace Scrapper.Api.Handlers
{
    public class GetSearchPositionsQueryHandler : IRequestHandler<GetSearchPositionsQuery, IEnumerable<int>>
    {
        private readonly IGoogleSearchService _searchService;
        private readonly IHtmlProcessor _htmlProcessor;
        private readonly IOptions<SearchSetting> _searchSetting;

        public GetSearchPositionsQueryHandler(IGoogleSearchService searchService, IHtmlProcessor htmlProcessor, IOptions<SearchSetting> searchSetting)
        {
            _searchService = searchService;
            _htmlProcessor = htmlProcessor;
            _searchSetting = searchSetting;
        }

        public async Task<IEnumerable<int>> Handle(GetSearchPositionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _searchService.GetHtmlString($"/search?num={_searchSetting.Value.ResultNumber}&q={request.Keyword}");
            var result = _htmlProcessor.GetSearchPositions(response, request.TargetUrl).ToList();
            return result;
        }
    }
}
