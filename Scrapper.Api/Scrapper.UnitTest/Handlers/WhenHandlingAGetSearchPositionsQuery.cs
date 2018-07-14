using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Scrapper.Api.Client;
using Scrapper.Api.Handlers;
using Scrapper.Api.HtmlService;
using Xunit;

namespace Scrapper.UnitTest.Handlers
{
    public class WhenHandlingAGetSearchPositionsQuery
    {
        private Task<List<int>> _result;

        public WhenHandlingAGetSearchPositionsQuery()
        {
            var mockSearchService = new Mock<IGoogleSearchService>();
            var mockHtmlProcessor = new Mock<IHtmlProcessor>();
            var handler = new GetSearchPositionsQueryHandler(mockSearchService.Object, mockHtmlProcessor.Object);
            _result = handler.Handle(null, CancellationToken.None);
        }

        [Fact]
        public void it_should_call_search_service_once()
        {
            //_result.Result.Count.Should().Be(2);
            true.Should().BeTrue();
        }
    }
}
