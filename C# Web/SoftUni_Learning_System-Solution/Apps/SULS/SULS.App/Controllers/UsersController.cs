using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProblemsService problemsService;

        public UsersController(IUsersService usersService, IProblemsService problemsService)
        {
            this.usersService = usersService;
            this.problemsService = problemsService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.usersService.GetUserOrNull(input.Username, input.Password);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            var problems = this.problemsService
                .GetAllProblems()
                .Select(p => new ProblemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count
                })
                .ToList();

            return this.View(new ProblemListViewModel { Problems = problems }, "../Home/IndexLoggedIn");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}