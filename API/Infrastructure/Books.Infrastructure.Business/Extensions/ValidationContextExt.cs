using Books.Domain.Core.Enums;
using Books.Domain.Core.Validator;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Extensions
{
    public static class ValidationContextExt
    {
        public static Task<bool> AddErrors<T>(this ValidationContext<T> context, string argument, List<ValidationError> errors)
        {
            context.MessageFormatter.AppendArgument(argument, new APIValidation
            {
                Details = errors,
                ErrorType = ErrorType.ValidationError
            });
            return Task.FromResult<bool>(!errors.Any());
        }
    }
}
