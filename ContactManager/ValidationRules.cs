using System;
using System.Globalization;
using System.Windows.Controls;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ContactManager
{
    public enum ValidationRules { Length, Email, Phone };

    public interface IValidation
    {
        string Name { get; }
        string Description { get; }
    }

    public class EmailValidationRule : ValidationRule, IValidation
    {
        public string Tmp { get; set; }
        public string Name => "Email rule";
        public string Description => "A rule checking if the legth of the text has is >= 5 characters";

        public EmailValidationRule()
        {
        }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = (string)value;

            try
            {
                MailAddress address = new MailAddress(email == "" ? " " : email);
                if (address.Address == email)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, "Incorrect email address");
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Invalid input");
            }
        }
    }

    public class PhoneValidationRule : ValidationRule, IValidation
    {
        public string Tmp { get; set; }

        public string Name => "Phone rule";
        public string Description => "A rule checking if the phone number is in the XXX-XXX-XXX format";

        public PhoneValidationRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex("^[0-9]{3}-[0-9]{3}-[0-9]{3}$");
            string phone = (string)value;
            
            if (phone != "" && regex.IsMatch(phone.ToString()))
            {
                return ValidationResult.ValidResult;
            }
            
            return new ValidationResult(false, "Invalid phone number\nFormat: xxx-xxx-xxx");
        }
    }

    public class ContentLengthValidationRule : ValidationRule, IValidation
    {
        public string TmpName { get; set; }
        public string TmpSurname { get; set; }

        private int minLength = 2;

        public string Name => "Content length rule";
        public string Description => $"A rule checking if the legth of the text has is >= {minLength} characters";

        public ContentLengthValidationRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string content = (string)value;

            return content.Length >= minLength
                ? ValidationResult.ValidResult
                : new ValidationResult(false, $"Value must have at least {minLength} characters!");
        }
    }
}
