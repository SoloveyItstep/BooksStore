using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System;
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
            RuleFor(x => x.Id).MustAsync(async (model, id, context, cancellationToken) => { 
                return await ValidateUser(id, context, cancellationToken).ConfigureAwait(false);
            });
        }

        private async Task<bool> ValidateUser(string id, ValidationContext<DeleteUserQuery> context, CancellationToken cancellationToken)
        {
            List<ValidationError> errors = new();
            if(!Guid.TryParse(id, out Guid userId))
                errors.Add(new ValidationError("Id", "User Id is invalid"));
            else if (await _userRepository.Get(x => x.Id == userId, cancellationToken).ConfigureAwait(false) == null)
                errors.Add(new ValidationError("User", "Invalid user data"));
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
