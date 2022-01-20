using Books.Domain.Core.Constants;
using Books.Domain.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Services.BootstrapUser
{
    public static class InitDefaulrUserService
    {
        private static readonly string email = "super@admin.com";

        public static async Task InitUserAndRoles(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await CreateUpdateUser(userManager).ConfigureAwait(false);
            await CreateRoles(serviceProvider.GetService<RoleManager<StoreRole>>(), userManager, user).ConfigureAwait(false);
        }

        /// <summary>
        /// Create roles (Admin, User) and 
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="userManager"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private static async Task CreateRoles(RoleManager<StoreRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            var roles = await roleManager.Roles.ToListAsync().ConfigureAwait(false);
            if(!roles.Any(x => x.Name == RolesList.Admin))
            {
                await roleManager.CreateAsync(new StoreRole {
                    Name = RolesList.Admin,
                    Id = Guid.NewGuid(),
                    NormalizedName = RolesList.Admin
                }).ConfigureAwait(false);
            }
            if (!roles.Any(x => x.Name == RolesList.User))
            {
                await roleManager.CreateAsync(new StoreRole
                {
                    Name = RolesList.User,
                    Id = Guid.NewGuid(),
                    NormalizedName = RolesList.User
                }).ConfigureAwait(false);
            }
            if(!await userManager.IsInRoleAsync(user, RolesList.Admin).ConfigureAwait(false))
                await userManager.AddToRoleAsync(user, RolesList.Admin).ConfigureAwait(false);
            if (!await userManager.IsInRoleAsync(user, RolesList.User).ConfigureAwait(false))
                await userManager.AddToRoleAsync(user, RolesList.User).ConfigureAwait(false);
        }

        private static async Task<ApplicationUser> CreateUpdateUser(UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByEmailAsync(email).ConfigureAwait(false);
            var userModel = await GetModel().ConfigureAwait(false);

            if (user == null)
                await userManager.CreateAsync(userModel).ConfigureAwait(false);
    
            return user ?? userModel;
        }

        private static async Task<ApplicationUser> GetModel()
        {
            using var hmac = new HMACSHA512();
            byte[] hash = await hmac.ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes("QadminQ"))).ConfigureAwait(false);
            return new ApplicationUser
            {
                Id = Guid.NewGuid(),
                AccessFailedCount = 0,
                ConcurrencyStamp = string.Empty,
                Birthday = DateTime.Now,
                Email = email,
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                PhoneNumber = "123456789",
                NormalizedEmail = email,
                NormalizedUserName = "admin",
                PhoneNumberConfirmed = true,
                Surename = "admin",
                UserName = "admin",
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = hmac.Key
            };
        }
    }
}
