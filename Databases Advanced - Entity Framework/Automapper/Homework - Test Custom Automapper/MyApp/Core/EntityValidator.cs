using MyApp.Core.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Core
{
    public class EntityValidator : IEntityValidator
    {
        public bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
