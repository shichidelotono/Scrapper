using System.Collections.Generic;
using Scrapper.Api.Representation.Extension;

namespace Scrapper.Api.Representation
{
    public class SearchPositionRepresentation
    {
        public IEnumerable<int> Positions { get; }

        public SearchPositionRepresentation(IEnumerable<int> positions)
        {
            Positions = positions.ToRepresentationalPositions();
        }
    }
}
