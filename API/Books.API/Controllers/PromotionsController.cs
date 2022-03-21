using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Promotions;
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

        [HttpPost("promotions")]
        [ProducesResponseType(typeof(List<PromotionDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PromotionDto>>> GetPromotions(PromotionsQuery query)
        {
            var result = await this._mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("promotions-light")]
        [ProducesResponseType(typeof(List<PromotionShortDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PromotionShortDto>>> GetPromotionsShort(PromotionsShortQuery query)
        {
            var result = await this._mediator.Send(query);
            return Ok(result);
        }
    }
}
