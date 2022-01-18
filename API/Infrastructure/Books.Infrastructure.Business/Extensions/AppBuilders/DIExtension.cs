using Books.Infrastructure.Business.Services.Security;
using Books.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure.Business.Extensions.AppBuilders
{
    public static class DIExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            //Scrutor
            services.Scan(scan => scan
                .FromAssemblyOf<TokenService>()
                .AddClasses(x => x.InNamespaces("Books.Infrastructure.Business"))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<BooksRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
