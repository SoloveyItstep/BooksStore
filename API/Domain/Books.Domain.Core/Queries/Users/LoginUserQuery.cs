using Books.Domain.Core.DTOs;
using MediatR;

namespace Books.Domain.Core.Queries.Users
{
    public class LoginUserQuery: IRequest<AccountDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
