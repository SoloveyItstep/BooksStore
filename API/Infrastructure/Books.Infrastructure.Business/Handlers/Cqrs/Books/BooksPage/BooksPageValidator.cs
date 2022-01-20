using Books.Domain.Core.Books.Queries;
using Books.Domain.Core.Validator;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Books.BooksPage
{
    public class BooksPageValidator: AbstractValidator<BooksPageQuery>
    {
        public BooksPageValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) =>
            {
                return await ValidateLogin(query, context, cancellationToken);
            });
        }

        private async Task<bool> ValidateLogin(BooksPageQuery query, ValidationContext<BooksPageQuery> context,
            CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();

            if (query.CurrentPage <= 0)
            {
                errors.Add(new ValidationError("CurrentPage", "Current Page has invalid value"));
            }
            if (query.PageSize <= 0)
            {
                errors.Add(new ValidationError("PageLength", "Page Length has invalid value"));
            }
            return await context.AddErrors("Get books for page view", errors).ConfigureAwait(false);
        }
    }
}
