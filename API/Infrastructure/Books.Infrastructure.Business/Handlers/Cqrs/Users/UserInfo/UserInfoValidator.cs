using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UserInfo
{
    public class UserInfoValidator: AbstractValidator<UserInfoQuery>
    {
        public UserInfoValidator(IUserRepository repository)
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Id).MustAsync(async (model, id, context, cancellationToken) =>
            {
                return await ValidateUser(id, context, repository, cancellationToken).ConfigureAwait(false);
            });
        }

        private static async Task<bool> ValidateUser(string id, ValidationContext<UserInfoQuery> context,
            IUserRepository repository, CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();
            if(!Guid.TryParse(id, out var userId))
                errors.Add(new ValidationError("Id", "Invalid userId"));
            else if ((await repository.Get(x => x.Id == Guid.Parse(id), cancellationToken)) == null)
                errors.Add(new("User", $"User does not exist"));
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
