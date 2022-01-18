using Books.Infrastructure.Data.DBContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController: ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseApiController(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
