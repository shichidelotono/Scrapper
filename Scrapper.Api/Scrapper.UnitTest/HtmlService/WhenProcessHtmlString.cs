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

        [Fact]
        public void it_should_return_empty_result_when_html_note_does_not_contain_class_g()
        {
            // setup
            var givenHtmlString = "<html><body><div><a href=\'www.facebook.com\'/></div></body></html>";
            var givenTarget = "www.facebook.com";

            // act
            var result = _htmlProcessor.GetSearchPositions(givenHtmlString, givenTarget).ToList();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void it_should_return_empty_result_when_html_note_does_not_contain_div_dom_element()
        {
            // setup
            var givenHtmlString = "<html><body><span><a href=\'www.facebook.com\'/></span></body></html>";
            var givenTarget = "www.facebook.com";

            // act
            var result = _htmlProcessor.GetSearchPositions(givenHtmlString, givenTarget).ToList();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void it_should_return_empty_result_when_html_note_does_not_contain_target_string()
        {
            // setup
            var givenHtmlString = "<html><body><span><a href=\'www.woolworths.com\'/></span></body></html>";
            var givenTarget = "www.facebook.com";

            // act
            var result = _htmlProcessor.GetSearchPositions(givenHtmlString, givenTarget).ToList();

            // assert
            Assert.Empty(result);
        }
    }
}
