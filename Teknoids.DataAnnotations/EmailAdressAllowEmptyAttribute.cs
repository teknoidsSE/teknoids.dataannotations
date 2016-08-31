using System;
using System.ComponentModel.DataAnnotations;

namespace Teknoids.DataAnnotations
{
    public class EmailAddressAllowEmptyAttribute : ValidationAttribute
    {
        private EmailAddressAttribute _wrappedAttribute = new EmailAddressAttribute();
        public EmailAddressAllowEmptyAttribute()
        {
            
    }

        public EmailAddressAllowEmptyAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
            
        }

        public EmailAddressAllowEmptyAttribute(string errorMessage) : base(errorMessage)
        {
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var s = value as string;
            if (s != null && s == string.Empty)
            {
                return ValidationResult.Success; 
            }
            else
            {
                var isValid = _wrappedAttribute.IsValid(value);

                return !isValid
               ? new ValidationResult($"{value} is not a valid email")
               : ValidationResult.Success;
            }
        }
    }
}