using System;
using System.ComponentModel.DataAnnotations;

namespace Teknoids.DataAnnotations
{
    /// <summary>
    /// validates a country code string according to Iso codes supported by CompanyLoans
    /// </summary>
    public class DateTimeOffsetAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateoffset = new DateTimeOffset();
            var x = value as string;
            var z = value as DateTimeOffset?;


            if ((z != null && z.Value != DateTimeOffset.MinValue) || (!string.IsNullOrEmpty(x) && System.DateTimeOffset.TryParse(x, out dateoffset)))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{value} is not a valid datetimeoffset");

        }
    }
}