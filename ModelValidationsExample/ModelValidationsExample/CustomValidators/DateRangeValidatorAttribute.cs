using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        string OtherPropertyName { get; set; }

        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //get toDate value
                DateTime toDate = Convert.ToDateTime(value);

                //get fromDate value
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
