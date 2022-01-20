using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.LoginUser
{
    public class LoginUserValidator: AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator(IUserRepository repository)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) =>
            {
                return await ValidateLogin(query, repository, context, cancellationToken);
            });
        }

        private static async Task<bool> ValidateLogin(LoginUserQuery query, IUserRepository repository, ValidationContext<LoginUserQuery> context,
            CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();

            var user = await repository.Get(x => x.Email == query.Email, cancellationToken).ConfigureAwait(false);
            if(user == null)
            {
                errors.Add(new ValidationError("User", "Invalid Email or Password"));
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            }

            if(string.IsNullOrEmpty(query.Email))
                errors.Add(new ValidationError(nameof(query.Email), "Field is mandatory"));
            if (string.IsNullOrEmpty(query.Password))
                errors.Add(new ValidationError(nameof(query.Password), "Field is mandatory"));

            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
