using Books.Domain.Core.Validator;
using System.Collections.Generic;
using System.Linq;

namespace Books.Infrastructure.Business.Validators
{
    internal static class UserValidator
    {
        private static readonly string characters = "/'\"\\;:.>,<?`~@#$%^&*()!№_=+";

        public static List<ValidationError> ValidateName(string fieldName, string name, int minLength, int maxLength, bool isRequired)
        {
            List<ValidationError> errors = new();
            if (string.IsNullOrEmpty(name))
            {
                if (isRequired)
                {
                    errors.Add(new ValidationError(fieldName, $"Field is mandatory"));
                }
                return errors;
            }
            if (isRequired)
            {
                MinLength(errors, fieldName, name, minLength);
                MaxLength(errors, fieldName, name, maxLength);
            }
            else
            {
                if (name.Length > minLength)
                {
                    MaxLength(errors, fieldName, name, maxLength);
                }
                if (name.Length < minLength)
                {
                    errors.Add(new ValidationError(fieldName, $"Min length is {minLength} or empty"));
                }
            }
            if (characters.Any(character => name.Contains(character)))
            {
                errors.Add(new ValidationError(fieldName, $"Field contains forbidden characters: {characters}"));
            }
            return errors;
        }

        public static List<ValidationError> ValidatePassword(string password)
        {
            List<ValidationError> errors = new();
            if (string.IsNullOrEmpty(password))
            {
                errors.Add(new ValidationError("Password", "Field is mandatory"));
                return errors;
            }
            if (password.Length < 6)
                errors.Add(new ValidationError("Password", "Min length is 6"));
            if (password.Length > 16)
                errors.Add(new ValidationError("Password", "Max length is 16"));
            if (!password.Any(char.IsUpper))
                errors.Add(new ValidationError("Password", "At least one uppercase letter is mandatory"));
            if (!password.Any(char.IsLower))
                errors.Add(new ValidationError("Password", "At least one lowercase letter is mandatory"));
            if (!characters.Any(character => password.Contains(character)))
                errors.Add(new ValidationError("Password", "At least one character is mandatory"));
            if (!password.Any(char.IsNumber))
                errors.Add(new ValidationError("Password", "At least one number is mandatory"));

            return errors;
        }

        public static List<ValidationError> ValidateEmail(string email)
        {
            List<ValidationError> errors = new();
            if (string.IsNullOrEmpty(email))
            {
                errors.Add(new ValidationError("Email", "Field is mandatory"));
                return errors;
            }
            string trimEmail = email.Trim();
            if (trimEmail.EndsWith("."))
                errors.Add(new ValidationError("Email", "Invalid Email: ends with '.'"));
            try
            {
                var mailAddr = new System.Net.Mail.MailAddress(trimEmail);
                if (mailAddr.Address != trimEmail)
                    errors.Add(new ValidationError("Email", "Invalid email address"));
            }
            catch
            {
                errors.Add(new ValidationError("Email", "Invalid email address"));
            }
            return errors;
        }

        public static List<ValidationError> ValidatePhone(string phone)
        {
            List<ValidationError> errors = new();
            if (string.IsNullOrEmpty(phone))
            {
                errors.Add(new ValidationError("Pnone", "Field is mandatory"));
                return errors;
            }
            string trimPhone = phone.Trim();
            if (trimPhone.StartsWith('+'))
                trimPhone = trimPhone[1..];
            string errorText = "Invalid phone number. Phone number should contain only numbers and may start with +";
            if (!trimPhone.Any(char.IsNumber))
                errors.Add(new ValidationError("Phone", errorText));
            if (trimPhone.Length < 9)
                errors.Add(new ValidationError("Phone", "Min length is 9"));
            if (trimPhone.Length > 16)
                errors.Add(new ValidationError("Phone", "Max length is 16"));

            return errors;
        }

        private static bool MinLength(List<ValidationError> errors, string fieldName, string name, int minLength)
        {
            if (name.Length < minLength)
            {
                errors.Add(new ValidationError(fieldName, $"Min length is {minLength}"));
                return false;
            }
            return true;
        }

        private static bool MaxLength(List<ValidationError> errors, string fieldName, string name, int maxLength)
        {
            if (name.Length > maxLength)
            {
                errors.Add(new ValidationError(fieldName, $"Max length is {maxLength}"));
                return false;
            }
            return true;
        }
    }
}
