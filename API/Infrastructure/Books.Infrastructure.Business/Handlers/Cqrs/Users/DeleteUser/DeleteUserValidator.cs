using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.DeleteUser
{
    public class DeleteUserValidator: AbstractValidator<DeleteUserQuery>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserValidator(IUserRepository repository)
        {
            _userRepository = repository;

            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) => { 
                return await ValidateUser(query, context, cancellationToken).ConfigureAwait(false);
            });
        }

        private async Task<bool> ValidateUser(DeleteUserQuery query, ValidationContext<DeleteUserQuery> context, CancellationToken cancellationToken)
        {
            List<ValidationError> errors = new();
            if (string.IsNullOrEmpty(query.Email))
                errors.Add(new ValidationError(nameof(query.Email), "Field is mandatory"));
            else if (await _userRepository.Get(x => x.Email == query.Email, cancellationToken).ConfigureAwait(false) == null)
                errors.Add(new ValidationError("User", "User with such email does not exist"));
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
