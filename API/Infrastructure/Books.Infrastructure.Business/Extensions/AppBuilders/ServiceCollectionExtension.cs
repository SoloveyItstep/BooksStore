using Books.Infrastructure.Business.Services.BootstrapUser;
using Books.Infrastructure.Business.Configuration;
using Books.Infrastructure.Business.Handlers.Cqrs.Users.LoginUser;
using Books.Infrastructure.Business.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Books.Infrastructure.Business.Extensions.AppBuilders
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabases(configuration);

            services.AddApplicationInsightsTelemetry(configuration);

            services.AddMediatR(typeof(LoginUserHandler).Assembly);

            services.AddInjection();

            services.AddControllers();

            services.AddFluentValidator();

            services.AddCors();

            services.AddSwagger();

            services.AddAuth(configuration);

            services.AddAutoMapper(exp => exp.AddProfile(new AutoMapperConfigProfile()));

            //InitDefaulrUserService.InitUserAndRoles(services.BuildServiceProvider()).GetAwaiter().GetResult();

            return services;
        }

        public static IApplicationBuilder ConfigureEnvironmantExtensions(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books.API v1"));
            }
            return app;
        }

        public static IApplicationBuilder ConfigureExtensions(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200", "https://boocksstorage.z16.web.core.windows.net"));
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            return app;
        }
    }
}
