using Books.Domain.Core.Queries;
using Books.Domain.Core.Queries.Users;
using Books.Infrastructure.Data.DBContexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    public class ErrorController : BaseApiController
    {
        public ErrorController( IMediator mediator)
           : base(mediator)
        { }

        [Authorize]
        [HttpPost("get401")]
        public ActionResult Get401()
        {
            return Ok();
        }

        [HttpPost("get400")]
        public ActionResult Get400()
        {
            return BadRequest();
        }

        [HttpPost("get500")]
        public ActionResult<Task> Get500()
        {
            //var user = _context.ApplicationUsers.Find(-1);
            //user.toString();
            return Ok();
        }

        [HttpPost("get404")]
        public ActionResult Get404()
        {
            return NotFound();
        }

        [HttpPost("get400validation")]
        public async Task<ActionResult> Get400Validation()
        {
            LoginUserQuery query = new() { Email = string.Empty, Password = "" };
            var result = await this._mediator.Send(query);
            return Ok(result);
        }
    }
}
