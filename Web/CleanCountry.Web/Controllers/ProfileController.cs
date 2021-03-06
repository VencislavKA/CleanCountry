namespace CleanCountry.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Common.Repositories;
    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using CleanCountry.Web.ViewModels.Profile;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        public ProfileController(UserManager<ApplicationUser> userManager, IProjectsService projectsService, IRepository<ApplicationRole> roleRepository)
        {
            this.UserManager = userManager;
            this.ProjectsService = projectsService;
            this.RoleRepository = roleRepository;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public IProjectsService ProjectsService { get; }

        public IRepository<ApplicationRole> RoleRepository { get; }

        public async Task<IActionResult> Index()
        {
            var user = await this.UserManager.GetUserAsync(this.User);
            var projects = this.ProjectsService.GetMyProjects(user.Id).ToList();
            string role = string.Empty;
            if (user.Role == Role.Partisipient)
            {
                role = "Уастник";
                projects = this.ProjectsService.GetProjectsImIn(user.Id).ToList();
            }
            else if (user.Role == Role.Organizator)
            {
                role = "Организатор";
            }
            else if (user.Role == Role.Admin)
            {
                role = "Админ";
            }

            var result = new ProfileViewModel() { UserName = user.UserName, Projects = projects, Email = user.Email, Role = role };
            return this.View(result);
        }
    }
}
