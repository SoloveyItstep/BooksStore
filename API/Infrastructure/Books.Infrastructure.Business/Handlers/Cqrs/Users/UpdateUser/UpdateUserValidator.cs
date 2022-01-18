using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Business.Handlers.Extensions;
using Books.Infrastructure.Business.Validators;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.UpdateUser
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserQuery>
    {
        public UpdateUserValidator(IUserRepository repository)
        {
            //model is empty
            RuleFor(x => x).NotNull();

            //user exists
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) => { 
                return await ValidateUser(query, context, repository, cancellationToken).ConfigureAwait(false);
            });

            // First name
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MustAsync(async (model, firstName, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidateName(nameof(model.FirstName), firstName, 2, 15, true);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });

            //Last name
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).MustAsync(async (model, lastName, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidateName(nameof(model.LastName), lastName, 2, 30, true);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });

            //Surename
            RuleFor(x => x.Surename).MustAsync(async (model, surename, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidateName(nameof(model.Surename), surename, 2, 30, true);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });

            //Phone
            RuleFor(x => x.Phone).MustAsync(async (model, phone, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidatePhone(phone);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });
        }

        private static async Task<bool> ValidateUser(UpdateUserQuery query, ValidationContext<UpdateUserQuery> context,
            IUserRepository repository, CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();

            if ((await repository.Get(x => x.Email == query.Email, cancellationToken)) == null)
                errors.Add(new("User", $"User with such Email ('{query.Email}') does not exist"));
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
