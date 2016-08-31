using System;
using System.ComponentModel.DataAnnotations;

namespace Teknoids.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is string == false && value is Guid == false)
                return ValidationResult.Success;

            var guid = value as Guid? ?? Guid.Empty;
            var s = value as string;
            if (s == null)
                return guid == Guid.Empty
                    ? new ValidationResult($"{value} cannot be an empty Guid")
                    : ValidationResult.Success;
            if (Guid.TryParse(s, out guid) == false)
                return new ValidationResult($"{value} is not a valid Guid");

            return guid == Guid.Empty ? new ValidationResult($"{value} cannot be an empty Guid") : ValidationResult.Success;
        }
    }
}