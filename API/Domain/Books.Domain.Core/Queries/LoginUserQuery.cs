using Books.Domain.Core.DTOs;
using MediatR;

namespace Books.Domain.Core.Queries
{
    public class LoginUserQuery: IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
