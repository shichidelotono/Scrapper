using System.Collections.Generic;
using System.Linq;

namespace Scrapper.Api.Representation.Extension
{
    public static class RepresentationExtension
    {
        public static IEnumerable<int> ToRepresentationalPositions(this IEnumerable<int> positions)
        {
            positions = positions.ToList();

            return !positions.Any() ? new List<int>() : positions.Select(p => p+1);
        }
    }
}
