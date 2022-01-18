using Books.Domain.Core.Queries;
using Books.Domain.Core.Validator;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Business.Handlers.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Handlers.Cqrs.PromotionsCqrs
{
    public class PromotionsValidator: AbstractValidator<PromotionsQuery>
    {
        private readonly ILanguagesRepository _languagesRepository;
        public PromotionsValidator(ILanguagesRepository languagesRepository)
        {
            _languagesRepository = languagesRepository;
            RuleFor(x => x).NotNull();
            RuleFor(x => x).MustAsync(async (model, query, context, cancellationToken) => await ValidatePromorions(model, context, cancellationToken));
        }

        private async Task<bool> ValidatePromorions(PromotionsQuery query, ValidationContext<PromotionsQuery> context,
            CancellationToken cancellationToken)
        {
            var errors = new List<ValidationError>();
            var languages = await _languagesRepository.LanguageCodes(cancellationToken).ConfigureAwait(false);

            if (string.IsNullOrEmpty(query.Language))
            {
                errors.Add(new ValidationError("Language", "Language value is required"));
            }
            else if(!languages.Any(x => string.Equals(x, query.Language, StringComparison.OrdinalIgnoreCase)))
            {
                errors.Add(new ValidationError("Language", $"Unknown language code: {query.Language}"));
            }
            return await context.AddErrors("Get books for page view", errors).ConfigureAwait(false);
        }
    }
}
