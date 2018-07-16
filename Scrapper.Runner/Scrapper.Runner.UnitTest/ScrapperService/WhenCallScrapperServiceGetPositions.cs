using System.Collections.Generic;
using System.Linq;
using Moq;
using Scrapper.Runner.ApiClient;
using Scrapper.Runner.ConfigService;
using Scrapper.Runner.Response;
using Xunit;

namespace Scrapper.Runner.UnitTest.ScrapperService
{
    public class WhenCallScrapperServiceGetPositions
    {
        private Mock<IApiClientHandler> _mockApiClientHandler;
        private Mock<IConfigService> _mockConfigService;
        private Runner.ScrapperService.ScrapperService _scrapperService;

        public WhenCallScrapperServiceGetPositions()
        {
            _mockApiClientHandler = new Mock<IApiClientHandler>();
            _mockConfigService = new Mock<IConfigService>();
            _scrapperService = new Runner.ScrapperService.ScrapperService(_mockApiClientHandler.Object, _mockConfigService.Object);
        }

        [Fact]
        public void it_should_configure_handler_once()
        {
            // setup
            var givenUrl = "/serach?keyword=facebook";
            var mockEndpoint = "http://localhost:5000";
            var mockResult = "result";
            _mockConfigService.Setup(c => c.GetApiEndpoint()).Returns(mockEndpoint);
            _mockApiClientHandler.Setup(a => a.ConfigureApiClient(mockEndpoint));
            _mockApiClientHandler.Setup(a => a.Get(givenUrl)).Returns(mockResult);
            _mockApiClientHandler.Setup(a => a.GetPositions(mockResult))
                .Returns(new PositionsResponse {Positions = new List<int>()});

            // act
            var dto = _scrapperService.GetPositions(givenUrl);

            // verify
            _mockApiClientHandler.Verify(a => a.ConfigureApiClient(mockEndpoint), Times.Once);
        }

        [Fact]
        public void it_should_get_result_in_string_via_handler_once()
        {
            // setup
            var givenUrl = "/serach?keyword=facebook";
            var mockEndpoint = "http://localhost:5000";
            var mockResult = "result";
            _mockConfigService.Setup(c => c.GetApiEndpoint()).Returns(mockEndpoint);
            _mockApiClientHandler.Setup(a => a.ConfigureApiClient(mockEndpoint));
            _mockApiClientHandler.Setup(a => a.Get(givenUrl)).Returns(mockResult);
            _mockApiClientHandler.Setup(a => a.GetPositions(mockResult))
                .Returns(new PositionsResponse {Positions = new List<int>()});

            // act
            var dto = _scrapperService.GetPositions(givenUrl);

            // verify
            _mockApiClientHandler.Verify(a => a.Get(givenUrl), Times.Once);
        }

        [Fact]
        public void it_should_get_api_endpoint_once()
        {
            // setup
            var givenUrl = "/serach?keyword=facebook";
            var mockEndpoint = "http://localhost:5000";
            var mockResult = "result";
            _mockConfigService.Setup(c => c.GetApiEndpoint()).Returns(mockEndpoint);
            _mockApiClientHandler.Setup(a => a.ConfigureApiClient(mockEndpoint));
            _mockApiClientHandler.Setup(a => a.Get(givenUrl)).Returns(mockResult);
            _mockApiClientHandler.Setup(a => a.GetPositions(mockResult))
                .Returns(new PositionsResponse {Positions = new List<int>()});

            // act
            var dto = _scrapperService.GetPositions(givenUrl);

            // verify
            _mockConfigService.Verify(a => a.GetApiEndpoint(), Times.Once);
        }

        [Fact]
        public void it_should_get_search_positions_result_once()
        {
            // setup
            var givenUrl = "/serach?keyword=facebook";
            var mockEndpoint = "http://localhost:5000";
            var mockResult = "result";
            _mockConfigService.Setup(c => c.GetApiEndpoint()).Returns(mockEndpoint);
            _mockApiClientHandler.Setup(a => a.ConfigureApiClient(mockEndpoint));
            _mockApiClientHandler.Setup(a => a.Get(givenUrl)).Returns(mockResult);
            _mockApiClientHandler.Setup(a => a.GetPositions(mockResult))
                .Returns(new PositionsResponse {Positions = new List<int>()});

            // act
            var dto = _scrapperService.GetPositions(givenUrl);

            // verify
            _mockApiClientHandler.Verify(a => a.GetPositions(mockResult), Times.Once);
        }

        [Fact]
        public void it_should_get_correct_positions_result()
        {
            // setup
            var givenUrl = "/serach?keyword=facebook";
            var mockEndpoint = "http://localhost:5000";
            var mockResult = "result";
            var mockResponse = new PositionsResponse { Positions = new List<int> { 1, 5 }};
            _mockConfigService.Setup(c => c.GetApiEndpoint()).Returns(mockEndpoint);
            _mockApiClientHandler.Setup(a => a.ConfigureApiClient(mockEndpoint));
            _mockApiClientHandler.Setup(a => a.Get(givenUrl)).Returns(mockResult);
            _mockApiClientHandler.Setup(a => a.GetPositions(mockResult))
                .Returns(mockResponse);

            // act
            var dto = _scrapperService.GetPositions(givenUrl).Positions.ToList();

            // assert
            Assert.Equal(dto[0], mockResponse.Positions.ToList()[0]);
            Assert.Equal(dto[1], mockResponse.Positions.ToList()[1]);
        }
    }
}
