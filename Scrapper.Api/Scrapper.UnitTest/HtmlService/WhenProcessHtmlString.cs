using System.Linq;
using Scrapper.Api.HtmlService;
using Xunit;

namespace Scrapper.UnitTest.HtmlService
{
    public class WhenProcessHtmlString
    {
        private IHtmlProcessor _htmlProcessor;

        public WhenProcessHtmlString()
        {
            _htmlProcessor = new HtmlProcessor();
        }

        [Fact]
        public void it_should_return_correct_result()
        {
            // setup
            var givenHtmlString = "<html><body><div><a href=\'www.facebook.com\'/></div><div class=\'g\'><a href=\'www.facebook.com\'/></div><div class=\'g\'><a href=\'www.woolworths.com.au\'/></div><div><a href=\'www.facebook.com\'/></div><div class=\'g\'><a href=\'www.facebook.com\'/></div></body></html>";
            var givenTarget = "www.facebook.com";

            // act
            var result = _htmlProcessor.GetSearchPositions(givenHtmlString, givenTarget).ToList();

            // assert
            Assert.Equal(2, result.Count);
            Assert.Equal(0, result[0]);
            Assert.Equal(2, result[1]);
        }
    }
}
