using Books.Domain.Core.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Books.Infrastructure.Business.Extensions.AppBuilders
{
    public static class ApplicationAuthenticationExtension
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                var key = Encoding.UTF8.GetBytes(configuration["JwtConfig:TokenKey"]);
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<DataContext>();

            return services;
        }
    }
}
