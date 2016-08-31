using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Teknoids.DataAnnotations.Core
{
    /// <summary>
    /// validates a country code string according to Iso codes supported by CompanyLoans
    /// </summary>
    public class CountryCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var code = value as string;

            var isValid = !(string.IsNullOrEmpty(code) || code.Length != 2);

            if (isValid)
            {
                try
                {
                    var countryCode = new RegionInfo(code);
                    
                }
                catch (Exception)
                {
                    isValid = false;
                }
            }
            
            return !isValid
                ? new ValidationResult($"{value} is not a valid country Code")
                : ValidationResult.Success;
        }
    }
}