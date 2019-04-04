using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public static class EntityValidator
    {
        public static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
