using Books.Domain.Core.Queries;
using Books.Domain.Core.Validator;
using Books.Infrastructure.Business.Handlers.Extensions;
using Books.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.RegisterUser
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserQuery>
    {
        public RegisterUserValidator(DataContext dbContext)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancelationToken) =>
            {
                return await ValidateUser(query, context, dbContext, cancelationToken).ConfigureAwait(false);
            });
            
        }
        
        private async Task<bool> ValidateUser(RegisterUserQuery query, ValidationContext<RegisterUserQuery> context,
            DataContext dbContext, CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();

            if((await dbContext.ApplicationUsers
                              .AsNoTracking()
                              .SingleOrDefaultAsync(x => x.UserName == query.UserName, cancellationToken)) != null)
            {
                errors.Add(new ("UserName", $"User '{query.UserName}' already exists"));
                return await context.AddErrors<RegisterUserQuery>("Register User validation", errors).ConfigureAwait(false);
            }
            if (string.IsNullOrEmpty(query.UserName))
            {
                errors.Add(new (nameof(query.UserName), $"Parameter '{nameof(query.UserName)}' is mandatory"));
            }
            if (string.IsNullOrEmpty(query.Password))
            {
                errors.Add(new (nameof(query.Password), $"Parameter '{nameof(query.Password)}' is mandatory"));
            }
            if (string.IsNullOrEmpty(query.PasswordConfirmation))
            {
                errors.Add(new (nameof(query.PasswordConfirmation), $"Parameter '{nameof(query.PasswordConfirmation)}' is mandatory"));
            }
            if(!string.Equals(query.Password, query.PasswordConfirmation))
            {
                errors.Add(new (nameof(query.PasswordConfirmation), $"Password and Password Confirmation have to be equal"));
            }
            if (string.IsNullOrEmpty(query.Email))
            {
                errors.Add(new (nameof(query.Password), $"Parameter '{nameof(query.Email)}' is mandatory"));
            }
            //TODO: phone validation
            return await context.AddErrors("Register User validation", errors).ConfigureAwait(false);
        }
    }
}
