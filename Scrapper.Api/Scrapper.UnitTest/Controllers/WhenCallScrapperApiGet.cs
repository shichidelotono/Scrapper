using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Scrapper.Api.Controllers;
using Scrapper.Api.Queries;
using Xunit;

namespace Scrapper.UnitTest.Controllers
{
    public class WhenCallScrapperApiGet
    {
        private Mock<IMediator> _mockMediator;
        private ScrapperController _controller;

        public WhenCallScrapperApiGet()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new ScrapperController(_mockMediator.Object);
        }

        [Fact]
        public void it_should_call_mediator_once()
        {
            // setup
            var givenResult = new List<int> {0, 3};
            _mockMediator.Setup(m => m.Send(It.IsAny<GetSearchPositionsQuery>(), CancellationToken.None)).Returns(Task.FromResult(givenResult.AsEnumerable()));
           
            // act
            var result = _controller.Get("face", "www.facebook.com");

            // verify
            _mockMediator.Verify(m => m.Send(It.IsAny<GetSearchPositionsQuery>(), CancellationToken.None), Times.Exactly(1));
        }

        [Fact]
        public void it_should_return_correct_result()
        {
            // setup
            var givenResult = new List<int> {0, 3};
            _mockMediator.Setup(m => m.Send(It.IsAny<GetSearchPositionsQuery>(), CancellationToken.None)).Returns(Task.FromResult(givenResult.AsEnumerable()));
           
            // act
            var result = _controller.Get("face", "www.facebook.com").Result.Positions.ToList();

            // assert
            Assert.Equal(1, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(2, result.Count);
        }
    }
}
