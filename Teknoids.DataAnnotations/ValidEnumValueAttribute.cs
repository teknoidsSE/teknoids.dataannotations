using System;
using System.ComponentModel.DataAnnotations;

namespace Teknoids.DataAnnotations
{
    /// <summary>
    /// Validates that an enum is valid
    /// </summary>
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return new ValidationResult($"{value} is not a valid enum");

            var enumType = value.GetType();
            var valid = Enum.IsDefined(enumType, value);
            return !valid ? new ValidationResult($"{value} is not a valid enum of type {enumType.Name}") : ValidationResult.Success;
        }
    }
}