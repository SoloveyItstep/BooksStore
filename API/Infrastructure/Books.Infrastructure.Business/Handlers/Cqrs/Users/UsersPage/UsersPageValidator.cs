using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Collections.Generic;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UsersPage
{
    public class UsersPageValidator: AbstractValidator<UsersPageQuery>
    {
        public UsersPageValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.CurrentPage).MustAsync(async(model, page, context, cancellationToken) => {
                List<ValidationError> errors = new();
                if (page < 1)
                    errors.Add(new ValidationError("CurrentPage", "Invalid page number"));

                return await context.AddErrors("User page", errors);
            });
            RuleFor(x => x.PageSize).MustAsync(async (model, page, context, cancellationToken) => {
                List<ValidationError> errors = new();
                if (page < 1)
                    errors.Add(new ValidationError("PageSize", "Invalid page size number"));

                return await context.AddErrors("", errors);
            });
        }
    }
}
