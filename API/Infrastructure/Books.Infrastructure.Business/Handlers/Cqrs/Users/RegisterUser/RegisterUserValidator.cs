using Books.Domain.Core.Queries.Users;
using Books.Domain.Core.Validator;
using Books.Infrastructure.Business.Validators;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Books.Domain.Interfaces.SQL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Books.Domain.Core.Identity;

namespace Books.Infrastructure.Business.Handlers.Cqrs.Users.RegisterUser
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserQuery>
    {
        

        public RegisterUserValidator(UserManager<ApplicationUser> userManager)
        {
            //model is empty
            RuleFor(x => x).NotNull();
            
            //user exists
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) =>
            {
                return await ValidateUser(query, context, userManager, cancellationToken).ConfigureAwait(false);
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

            //Password
            RuleFor(x => x.Password).MustAsync(async (model, password, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidatePassword(password);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });

            //Password confirmation
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) =>
            {
                return await ValidatePasswordConfirmation(query, context).ConfigureAwait(false);
            });

            //Email
            RuleFor(x => x.Email).MustAsync(async (model, email, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidateEmail(email);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });

            //Phone
            RuleFor(x => x.Phone).MustAsync(async (model, phone, context, cancellationToken) =>
            {
                var errors = UserValidator.ValidatePhone(phone);
                return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
            });
        }
        
        private static async Task<bool> ValidateUser(RegisterUserQuery query, ValidationContext<RegisterUserQuery> context,
            UserManager<ApplicationUser> userManager, CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();
            if (await userManager.FindByEmailAsync(query.Email) != null)
                errors.Add(new ("User", $"User with such Email ('{query.Email}') already exists"));
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }

        private static async Task<bool> ValidatePasswordConfirmation(RegisterUserQuery query, ValidationContext<RegisterUserQuery> context)
        {
            List<ValidationError> errors = new();
            if (string.IsNullOrEmpty(query.PasswordConfirmation))
                errors.Add(new(nameof(query.PasswordConfirmation), $"Parameter '{nameof(query.PasswordConfirmation)}' is mandatory"));
            else if (!string.Equals(query.Password, query.PasswordConfirmation))
                errors.Add(new(nameof(query.PasswordConfirmation), $"Password and Password Confirmation have to be equal"));
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
