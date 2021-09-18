using Books.Infrastructure.Business.Handlers.Cqrs.LoginUser;
using Books.Infrastructure.Business.Middleware;
using Books.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Books.Infrastructure.Business.Extensions.AppBuilders
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("BooksConnectionString")));

            services.AddApplicationInsightsTelemetry(configuration);

            services.AddMediatR(typeof(LoginUserHandler).Assembly); //  Assembly.GetExecutingAssembly()

            services.AddInjection();

            services.AddControllers();

            services.AddFluentValidator();

            services.AddCors();

            services.AddSwagger();

            services.AddAuth(configuration);  

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

        public static IApplicationBuilder ConfigureExtensions(this IApplicationBuilder app, IWebHostEnvironment env)
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


//{
//    "userName": "test",
//  "password": "test",
//  "passwordConfirmation": "test",
//  "email": "test@test.com",
//  "phone": "1234567890"
//}