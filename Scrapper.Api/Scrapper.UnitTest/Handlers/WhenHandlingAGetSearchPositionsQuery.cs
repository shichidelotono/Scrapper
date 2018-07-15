using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Scrapper.Api.AppSettings;
using Scrapper.Api.SearchService;
using Scrapper.Api.Handlers;
using Scrapper.Api.HtmlService;
using Scrapper.Api.Queries;
using Xunit;

namespace Scrapper.UnitTest.Handlers
{
    public class WhenHandlingGetSearchPositionsQuery
    {
        private Mock<IGoogleSearchService> _mockGoogleSearchService;
        private Mock<IHtmlProcessor> _mockHtmlProcessor;
        private Mock<IOptions<SearchSetting>> _mockSearchSetting;
        private GetSearchPositionsQueryHandler _handler;

        public WhenHandlingGetSearchPositionsQuery()
        {
            _mockGoogleSearchService = new Mock<IGoogleSearchService>();
            _mockHtmlProcessor = new Mock<IHtmlProcessor>();
            _mockSearchSetting = new Mock<IOptions<SearchSetting>>();
            _handler = new GetSearchPositionsQueryHandler(_mockGoogleSearchService.Object, _mockHtmlProcessor.Object, _mockSearchSetting.Object);
        }

        [Fact]
        public void it_should_call_search_setting_once()
        {
            // setup
            var givenRequest = new GetSearchPositionsQuery("google", "www.google.com");
            var givenResponse = Task.FromResult("<div></div>");
            _mockSearchSetting.Setup(s => s.Value).Returns(new SearchSetting { ResultNumber = 1 });
            _mockGoogleSearchService.Setup(g => g.GetHtmlString(It.IsAny<string>())).Returns(givenResponse);
            _mockHtmlProcessor.Setup(h => h.GetSearchPositions(givenResponse.Result, givenRequest.TargetUrl)).Returns(It.IsAny<IEnumerable<int>>());

            // act
            var result = _handler.Handle(givenRequest, CancellationToken.None);

            // assert
            _mockSearchSetting.Verify(g => g.Value, Times.Exactly(1));
        }

        [Fact]
        public void it_should_call_search_service_once()
        {
            // setup
            var givenRequest = new GetSearchPositionsQuery("google", "www.google.com");
            var givenResponse = Task.FromResult("<div></div>");
            var givenSetting = new SearchSetting {ResultNumber = 1};
            var givenUrl = $"/search?num={givenSetting.ResultNumber}&q={givenRequest.Keyword}";
            _mockSearchSetting.Setup(s => s.Value).Returns(givenSetting);
            _mockGoogleSearchService.Setup(g => g.GetHtmlString(It.IsAny<string>())).Returns(givenResponse);
            _mockHtmlProcessor.Setup(h => h.GetSearchPositions(givenResponse.Result, givenRequest.TargetUrl)).Returns(It.IsAny<IEnumerable<int>>());

            // act
            var result = _handler.Handle(givenRequest, CancellationToken.None);

            // assert
            _mockGoogleSearchService.Verify(g => g.GetHtmlString(givenUrl), Times.Exactly(1));
        }

        [Fact]
        public void it_should_call_html_processor_once()
        {
            // setup
            var givenRequest = new GetSearchPositionsQuery("google", "www.google.com");
            var givenResponse = Task.FromResult("<div></div>");
            _mockSearchSetting.Setup(s => s.Value).Returns(new SearchSetting { ResultNumber = 1 });
            _mockGoogleSearchService.Setup(g => g.GetHtmlString(It.IsAny<string>())).Returns(givenResponse);
            _mockHtmlProcessor.Setup(h => h.GetSearchPositions(givenResponse.Result, givenRequest.TargetUrl)).Returns(It.IsAny<IEnumerable<int>>());

            // act
            var result = _handler.Handle(givenRequest, CancellationToken.None);

            // assert
            _mockHtmlProcessor.Verify(g => g.GetSearchPositions(givenResponse.Result, givenRequest.TargetUrl), Times.Exactly(1));
        }
    }
}
