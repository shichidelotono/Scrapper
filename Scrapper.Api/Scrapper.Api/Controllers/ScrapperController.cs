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
            var query = new GetSearchPositionsQuery(keyword, targetUrl);
            var result = await _mediator.Send(query);

            return new SearchPositionRepresentation(result);
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
    }
}
