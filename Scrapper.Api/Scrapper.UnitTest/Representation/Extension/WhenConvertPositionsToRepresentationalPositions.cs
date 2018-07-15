using System.Collections.Generic;
using System.Linq;
using Scrapper.Api.Representation.Extension;
using Xunit;

namespace Scrapper.UnitTest.Representation.Extension
{
    public class WhenConvertPositionsToRepresentationalPositions
    {
        [Fact]
        public void it_should_return_correct_result()
        {
            // setup
            var givenPositions = new List<int> {0, 3};

            // act
            var result = givenPositions.ToRepresentationalPositions().ToList();

            // assert
            Assert.Equal(1, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void it_should_return_empty_result_when_given_empty_positions()
        {
            // setup
            var givenPositions = new List<int>();

            // act
            var result = givenPositions.ToRepresentationalPositions();

            // assert
            Assert.False(result.Any());
        }
    }
}
