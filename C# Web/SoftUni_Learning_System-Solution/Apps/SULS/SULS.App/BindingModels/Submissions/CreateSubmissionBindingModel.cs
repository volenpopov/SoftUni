using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.BindingModels.Submissions
{
    public class CreateSubmissionBindingModel
    {
        [RequiredSis]
        [StringLengthSis(30, 800, "Code length must be between 30 and 800 characters!")]
        public string Code { get; set; }
    }
}
