using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using Books.Services.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, AccountDto>
    {
        private readonly ITokenService _tokenService;
        private readonly string logginErrorMessage = "Username or password is not valid";
        private readonly IUserRepository _repository;

        public LoginUserHandler(IUserRepository repository, ITokenService tokenService)
        {
            this._repository = repository;
            this._tokenService = tokenService;
        }

        public async Task<AccountDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository
                .Get(x => x.Email.ToLower() == request.Email.ToLower(), cancellationToken)
                .ConfigureAwait(false);
            if(user == null)
            {
                return new AccountDto { Error = logginErrorMessage };
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = await hmac.ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(request.Password)), cancellationToken).ConfigureAwait(false);

            if (!StructuralComparisons.StructuralEqualityComparer.Equals(Convert.FromBase64String(user.PasswordHash), computeHash))
            {
                return new AccountDto { Error = logginErrorMessage };
            }

            return new AccountDto 
            { 
                Email = request.Email, 
                Token = await _tokenService.CreateToken(user), 
                FirstName = user.FirstName,
                Id = user.Id
            };
        }
    }
}
