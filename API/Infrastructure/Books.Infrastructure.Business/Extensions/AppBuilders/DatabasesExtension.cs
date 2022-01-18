using Books.Infrastructure.Data.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure.Business.Extensions.AppBuilders
{
    public static class DatabasesExtension
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("BooksConnectionString")));
            services.AddTransient(options => new MongoContext(configuration.GetConnectionString("MongoConnectionString")));
            services.AddStackExchangeRedisCache(options => {
                options.Configuration = configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "BooksStoreRedis";
            });

            return services;
        }
    }
}
