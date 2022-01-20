using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IMediator mediator)
           : base(mediator)
        { }

        [HttpPost("register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterUserQuery query)
        {
            if (User.Identity.IsAuthenticated)
            {
                return BadRequest("Can't register new user. Logout and repeat again");
            }
            AccountDto response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        [HttpPost("user-info/{id}")]
        public async Task<ActionResult<UserDto>> GetUserInfo(string id)
        {

            var user = await _mediator.Send(new UserInfoQuery(id)).ConfigureAwait(false);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AccountDto>> Login(LoginUserQuery query)
        {
            if (User.Identity.IsAuthenticated)
            {
                return BadRequest("Can't login new user. Logout and repeat again");
            }
            var userDto = await _mediator.Send(query).ConfigureAwait(false);
            if (string.IsNullOrEmpty(userDto.Error))
            {
                return Ok(userDto);
            }
            return BadRequest(userDto);
        }

        [HttpPut("update")]
        public async Task<ActionResult<AccountDto>> Update(UpdateUserQuery query)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest("Can't update not authenticated user");
            }
            AccountDto response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteUserQuery(id)).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("page/{current:int}/{pageSize:int}")]
        public async Task<ActionResult<List<UserShortDto>>> GetUsersPage(int current, int pageSize)
        {
            var users = await _mediator.Send(new UsersPageQuery(current, pageSize)).ConfigureAwait(false);
            return Ok(users);
        }
    }
}
