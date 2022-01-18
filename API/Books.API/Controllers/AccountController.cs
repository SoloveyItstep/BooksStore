using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    public class AccountController: BaseApiController
    {
        public AccountController(IMediator mediator)
           : base(mediator)
        { }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserQuery query)
        {
            if (User.Identity.IsAuthenticated)
            {
                return BadRequest("Can't register new user. Logout and repeat again");
            }
            UserDto response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginUserQuery query)
        {
            if (User.Identity.IsAuthenticated)
            {
                return BadRequest("Can't login new user. Logout and repeat again");
            }
            var userDto = await _mediator.Send(query).ConfigureAwait(false);
            if(string.IsNullOrEmpty(userDto.Error))
            {
                return Ok(userDto);
            }
            return BadRequest(userDto);
        }

        [HttpPut("update")]
        public async Task<ActionResult<UserDto>> Update(UpdateUserQuery query) 
        {
            if (User.Identity.IsAuthenticated)
            {
                return BadRequest("Can't update not authenticated user");
            }
            UserDto response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(string email)
        {
            await _mediator.Send(new DeleteUserQuery(email)).ConfigureAwait(false);
            return Ok();
        }
    }
}
