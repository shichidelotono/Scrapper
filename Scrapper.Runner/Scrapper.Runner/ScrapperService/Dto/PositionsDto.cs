using System.Collections.Generic;

namespace Scrapper.Runner.ScrapperService.Dto
{
    public class PositionsDto
    {
        public IEnumerable<int> Positions { get; }

        public PositionsDto(IEnumerable<int> positions)
        {
            Positions = positions;
        }
    }
}
