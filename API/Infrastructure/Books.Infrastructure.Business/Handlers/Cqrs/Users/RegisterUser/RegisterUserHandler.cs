using Books.Domain.Core.Account;
using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using Books.Services.Interfaces;
using MediatR;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserQuery, UserDto>
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public RegisterUserHandler(IUserRepository repository, ITokenService tokenService)
        {
            this._repository = repository;
            this._tokenService = tokenService;
        }

        public async Task<UserDto> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();
            var user = new ApplicationUser
            {
                Id = new Guid(),
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Surename = request.Surename?.Trim(),
                Email = request.Email.Trim(),
                Phone = request.Phone.Trim(),
                PasswordHash = await hmac.ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(request.Password)), cancellationToken).ConfigureAwait(false),
                PasswordSalt = hmac.Key,
                Birthday = request.Birthday
            };

            await _repository.Create(user, cancellationToken).ConfigureAwait(false);

            return new UserDto
            {
                FirstName = request.FirstName,
                Token = _tokenService.CreateToken(user.Email),
                Email = request.Email
            };
        }
    }
}
