using System.Collections.Generic;
using System.Linq;

namespace Scrapper.Api.Representation.Extension
{
    public static class RepresentationExtension
    {
        public static IEnumerable<int> ToRepresentationalPositions(this IEnumerable<int> positions)
        {
            if (positions == null)
                return new List<int>();

            positions = positions.ToList();

            if (!positions.Any())
                return new List<int>();

            return positions.Select(p => p+1);
        }
    }
}
