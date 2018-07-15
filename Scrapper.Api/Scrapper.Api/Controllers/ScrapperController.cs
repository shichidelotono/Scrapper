using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scrapper.Api.Queries;
using Scrapper.Api.Representation;

namespace Scrapper.Api.Controllers
{
    [Route("api/[controller]")]
    public class ScrapperController : Controller
    {
        private readonly IMediator _mediator;

        public ScrapperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<SearchPositionRepresentation> Get(string keyword, string targetUrl)
        {
            // create query
            var query = new GetSearchPositionsQuery(keyword, targetUrl);

            // sending query via mediator
            var result = await _mediator.Send(query);

            // convert result to client specific representational object
            return new SearchPositionRepresentation(result);
        }
    }
}
