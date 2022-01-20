using Books.Domain.Core.Constants;
using Books.Domain.Core.DTOs;
using Books.Domain.Core.Identity;
using Books.Domain.Core.Queries.Users;
using Books.Domain.Interfaces.SQL;
using Books.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserQuery, AccountDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterUserHandler(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AccountDto> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();
            byte[] hash = await hmac.ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(request.Password)), cancellationToken).ConfigureAwait(false);

            var user = new ApplicationUser
            {
                Id = new Guid(),
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Surename = request.Surename?.Trim(),
                Email = request.Email.Trim(),
                PhoneNumber = request.Phone.Trim(),
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = hmac.Key,
                Birthday = request.Birthday,
                AccessFailedCount = 0,
                EmailConfirmed = false,
                NormalizedEmail = request.Email.Trim(),
                NormalizedUserName = request.Email.Trim(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                UserName = request.Email.Trim()
            };

            var result = await _userManager.CreateAsync(user).ConfigureAwait(false);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RolesList.User).ConfigureAwait(false);
                return new AccountDto
                {
                    Id = user.Id,
                    FirstName = request.FirstName,
                    Token = await _tokenService.CreateToken(user),
                    Email = request.Email
                };
            }
            throw new Exception("Can't create user. Please try again");
        }
    }
}
