using System.Collections.Generic;

namespace Scrapper.Api.Representation
{
    public class SearchPositionRepresentation
    {
        public IEnumerable<int> Positions { get; }

        public SearchPositionRepresentation(IEnumerable<int> positions)
        {
            Positions = positions;
        }
    }
}
