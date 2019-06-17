using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Submissions;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Models;
using SULS.Services;
using System;
using System.Linq;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        [Authorize]
        public IActionResult Delete()
        {
            var submissionId = this.Request.QueryData.First().Value.First();

            var deletionCompletion = this.submissionsService.DeleteSubmission(this.User.Id, submissionId);

            if (!deletionCompletion)
            {
                var problemId = this.submissionsService.GetProblemOfSubmission(submissionId).Id;

                var problem = this.problemsService.GetCurrentProblemOrNull(problemId);

                var problemViewModel = new ProblemDetailsViewModel
                {
                    Name = problem.Name,
                };

                var problemSubmissions = this.submissionsService.GetProblemSubmissions(problemId);

                foreach (var sub in problemSubmissions)
                {
                    problemViewModel.Submissions.Add(
                        new SubmissionDetailsViewModel
                        {
                            AchievedResult = sub.AchievedResult,
                            MaxPoints = problem.Points,
                            CreatedOn = sub.CreatedOn.ToString("dd/MM/yyyy"),
                            SubmissionId = sub.Id,
                            Username = sub.User.Username
                        });
                }

                return this.View(problemViewModel, "../Problems/Details");
            }

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Create()
        {
            var currentProblemId = this.Request.QueryData.First().Value.First();

            var currentProblem = this.problemsService.GetCurrentProblemOrNull(currentProblemId);

            var currentProblemViewModel = new CurrentProblemViewModel
            {
                ProblemId = currentProblem.Id,
                Name = currentProblem.Name
            };

            return this.View(currentProblemViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateSubmissionBindingModel input)
        {
            var currentProblemId = this.Request.FormData.Skip(1).First().Value.First();
            var currentProblem = this.problemsService.GetCurrentProblemOrNull(currentProblemId);

            if (!this.ModelState.IsValid)
            {
                return this.Create(currentProblem);
            }
                        
            this.submissionsService.CreateSubmission(this.User.Id, currentProblem.Id, currentProblem.Points, input.Code);

            return this.Redirect("/");
        }

        private IActionResult Create(Problem currentProblem)
        {
            var currentProblemViewModel = new CurrentProblemViewModel
            {
                ProblemId = currentProblem.Id,
                Name = currentProblem.Name
            };

            return this.View(currentProblemViewModel);
        }
    }
}
