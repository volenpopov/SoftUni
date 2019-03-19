using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentDate = DateTime.Now;
            var expirationDate = (DateTime)value;

            if (expirationDate < currentDate)
            {
                return new ValidationResult("Credit card expired!");
            }

            return ValidationResult.Success;
        }
    }
}
