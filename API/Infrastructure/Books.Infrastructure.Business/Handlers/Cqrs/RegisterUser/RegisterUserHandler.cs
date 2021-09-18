using Books.Domain.Core.Account;
using Books.Domain.Core.DTOs;
using Books.Domain.Core.Queries;
using Books.Infrastructure.Data;
using Books.Services.Interfaces;
using MediatR;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserQuery, UserDto>
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public RegisterUserHandler(DataContext context, ITokenService tokenService)
        {
            this._context = context;
            this._tokenService = tokenService;
        }

        public async Task<UserDto> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();
            var user = new ApplicationUser
            {
                Id = new Guid(),
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                PasswordHash = await hmac.ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(request.Password)), cancellationToken).ConfigureAwait(false),
                PasswordSalt = hmac.Key
            };

            await _context.ApplicationUsers.AddAsync(user, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken);

            return new UserDto
            {
                UserName = request.UserName,
                Token = _tokenService.CreateToken(user.UserName)
            };
        }
    }
}
