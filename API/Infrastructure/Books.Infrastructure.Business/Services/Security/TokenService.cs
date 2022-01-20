using Books.Domain.Core.Identity;
using Books.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Services.Security
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<StoreRole> _roleManager;

        public TokenService(IConfiguration config, UserManager<ApplicationUser> userManager, RoleManager<StoreRole> roleManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:TokenKey"]));
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> CreateToken(ApplicationUser user)
        {
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetUserClaims(user).ConfigureAwait(false)),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<List<Claim>> GetUserClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var userClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole).ConfigureAwait(false);

                if(role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role).ConfigureAwait(false);
                    claims.AddRange(roleClaims);
                }
            }

            return claims;
        }
    }
}
