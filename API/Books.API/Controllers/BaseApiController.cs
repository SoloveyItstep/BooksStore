using Books.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController: ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly DataContext _context;

        public BaseApiController(DataContext context, IMediator mediator)
        {
            this._context = context;
            this._mediator = mediator;
        }
    }
}
