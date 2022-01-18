using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.LoginUser
{
    public class LoginUserValidator: AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) =>
            {
                return await ValidateLogin(query, context, cancellationToken);
            });
        }

        private static async Task<bool> ValidateLogin(LoginUserQuery query, ValidationContext<LoginUserQuery> context,
            CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();

            if(string.IsNullOrEmpty(query.Email))
            {
                errors.Add(new ValidationError(nameof(query.Email), "Field is mandatory"));
            }
            if (string.IsNullOrEmpty(query.Password))
            {
                errors.Add(new ValidationError(nameof(query.Password), "Field is mandatory"));
            }
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
