using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var problems = this.problemsService
                .GetAllProblems()
                .Select(p => new ProblemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count
                })
                .ToList();

                return this.View(new ProblemListViewModel { Problems = problems }, "IndexLoggedIn");
            }

            return this.View("Index");
        }
    }
}