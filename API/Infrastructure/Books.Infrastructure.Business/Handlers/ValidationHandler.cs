using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers
{
    public class ValidationHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationHandler(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = this.validators.Select(validator => validator.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .GroupBy(x => x.PropertyName)
                .SelectMany(x => x.Distinct());

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
