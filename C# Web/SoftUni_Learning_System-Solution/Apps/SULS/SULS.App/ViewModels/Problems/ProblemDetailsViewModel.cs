using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Submissions = new List<SubmissionDetailsViewModel>();
        }
        public string Name { get; set; }

        public ICollection<SubmissionDetailsViewModel> Submissions { get; set; }        
    }
}
