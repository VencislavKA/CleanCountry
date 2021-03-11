namespace CleanCountry.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using CleanCountry.Web.ViewModels;
    using CleanCountry.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(IProjectsService projectsService, IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.ProjectsService = projectsService;
            this.UserService = userService;
            this.UserManager = userManager;
        }

        public IProjectsService ProjectsService { get; }

        public IUserService UserService { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> AdminPage()
        {
            var users = this.UserService.GetAllUsers();
            var projects = this.ProjectsService.GetAllProjects();
            var user = await this.UserManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.RedirectToAction("Index");
            }

            var result = new AdminViewModel() { Projects = projects, Users = users, Role = user.Role };
            return this.View(result);
        }

        public async Task<IActionResult> DeleteProfile()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
