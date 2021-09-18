using Books.Infrastructure.Business.Extensions.AppBuilders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        private IWebHostEnvironment CurrentEnvironment { get; set; }
        private IConfiguration Configuration { get; }

        //all logic moved to business layer
        public void ConfigureServices(IServiceCollection services) => services.AddAPIServices(Configuration);

        //all logic moved to business layer
        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureEnvironmantExtensions(CurrentEnvironment);
            app.ConfigureExtensions(CurrentEnvironment);
        }
    }
}
