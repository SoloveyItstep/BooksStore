using Books.Infrastructure.Business.Handlers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure.Business.Extensions.AppBuilders
{
    public static class ValidatorExtension
    {
        

        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ValidationHandler<,>).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationHandler<,>));
            return services;
        }
    }
}
