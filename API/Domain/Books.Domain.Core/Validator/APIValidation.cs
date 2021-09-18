using Books.Domain.Core.Enums;
using System.Collections.Generic;

namespace Books.Domain.Core.Validator
{
    public class APIValidation
    {
        public IEnumerable<ValidationError> Details { get; set; }
        public ErrorType ErrorType { get; set; }
    }
}
