using Books.Domain.Core.Queries;
using Books.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    public class ErrorController : BaseApiController
    {
        public ErrorController(DataContext context, IMediator mediator)
           : base(context, mediator)
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
            var user = _context.ApplicationUsers.Find(-1);
            return Ok(user.ToString());
        }

        [HttpPost("get404")]
        public ActionResult Get404()
        {
            return NotFound();
        }

        [HttpPost("get400validation")]
        public async Task<ActionResult> Get400Validation()
        {
            LoginUserQuery query = new() { UserName = string.Empty, Password = "" };
            var result = await this._mediator.Send(query);
            return Ok(result);
        }
    }
}
