using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Teknoids.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly bool _shouldEValuate;
        
        RequiredAttribute requiredAttribute = new RequiredAttribute();
        public RequiredIfAttribute(bool shouldEValuate)
        {
            _shouldEValuate = shouldEValuate;
            


            //http://stackoverflow.com/questions/26354853/conditionally-required-property-using-data-annotations
        }

        public override bool IsValid(object value)
        {
            if (_shouldEValuate)
                return requiredAttribute.IsValid(value);

            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            if (!IsValid(value))
            {
                if (value == null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(
            CultureInfo.CurrentCulture,
            base.ErrorMessageString,
            name,
           "required field");
    }


    public override bool RequiresValidationContext => true;

}
}
