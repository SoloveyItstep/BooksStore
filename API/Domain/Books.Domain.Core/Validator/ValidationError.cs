namespace Books.Domain.Core.Validator
{
    public record ValidationError(string propertyName, string errorMessage);
}
