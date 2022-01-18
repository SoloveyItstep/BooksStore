using Books.Domain.Core.DbEntities.PromotionsModels;
using Books.Domain.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    public class PromotionsController: BaseApiController
    {
        public PromotionsController(IMediator mediator)
            :base(mediator)
        { }

        [HttpPost("promitions")]
        [ProducesResponseType(typeof(List<Promotions>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Promotions>>> GetPage(PromotionsQuery query)
        {
            var result = await this._mediator.Send(query);
            return Ok(result);
        }
    }
}
