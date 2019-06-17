using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Problems;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Details()
        {
            var currentProblemId = this.Request.QueryData.First().Value.First();

            var currentProblem = this.problemsService.GetCurrentProblemOrNull(currentProblemId);

            var currentProblemViewModel = new ProblemDetailsViewModel
            {
                Name = currentProblem.Name,               
            };

            var problemSubmissions = this.submissionsService.GetProblemSubmissions(currentProblemId);

            foreach (var sub in problemSubmissions)
            {
                currentProblemViewModel.Submissions.Add(
                    new SubmissionDetailsViewModel
                    {
                        AchievedResult = sub.AchievedResult,
                        MaxPoints = currentProblem.Points,
                        CreatedOn = sub.CreatedOn.ToString("dd/MM/yyyy"),
                        SubmissionId = sub.Id,
                        Username = sub.User.Username
                    });
            }

            return this.View(currentProblemViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProblemBindingModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.CreateProblem(this.User.Id, input.Name, input.Points);
            
            return this.Redirect("/");
        }
    }
}
