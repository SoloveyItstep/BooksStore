using Books.Domain.Core.Queries;
using Books.Domain.Core.Validator;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.LoginUser
{
    public class LoginUserValidator: AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancelationToken) =>
            {
                return await ValidateLogin(query, context, cancelationToken);
            });
        }

        private async Task<bool> ValidateLogin(LoginUserQuery query, ValidationContext<LoginUserQuery> context,
            CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();

            if(string.IsNullOrEmpty(query.UserName))
            {
                errors.Add(new ValidationError("UserName", "UserName is mandatory"));
            }
            if (string.IsNullOrEmpty(query.Password))
            {
                errors.Add(new ValidationError("Password", "Password is mandatory"));
            }
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
