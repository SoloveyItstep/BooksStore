using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries;
using Books.Infrastructure.Data;
using Books.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, UserDto>
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly string logginErrorMessage = "Username or password is not valid";


        public LoginUserHandler(DataContext context, ITokenService tokenService)
        {
            this._context = context;
            this._tokenService = tokenService;
        }

        public async Task<UserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower(), cancellationToken);
            if(user == null)
            {
                return new UserDto { Error = logginErrorMessage };
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = await hmac.ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(request.Password)), cancellationToken).ConfigureAwait(false);

            if (!StructuralComparisons.StructuralEqualityComparer.Equals(user.PasswordHash, computeHash))
            {
                return new UserDto { Error = logginErrorMessage };
            }

            return new UserDto { UserName = request.UserName, Token = _tokenService.CreateToken(request.UserName) };
        }
    }
}
