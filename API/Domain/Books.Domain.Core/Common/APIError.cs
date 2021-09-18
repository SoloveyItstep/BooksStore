using System.Collections.Generic;

namespace Books.Domain.Core.Common
{
    public record APIError(int StatusCode,  IEnumerable<APIErrorDetails> Details = null);
}
