using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.BindingModels.Problems
{
    public class CreateProblemBindingModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Problem name must be between 5 and 20 characters long!")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, "Points must be between 50 and 300!")]
        public int Points { get; set; }
    }
}
