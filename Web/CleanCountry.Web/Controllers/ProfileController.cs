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
    using Microsoft.Data.SqlClient.DataClassification;

    public class ProfileController : Controller
    {
        public ProfileController(
            UserManager<ApplicationUser> userManager,
            IProjectsService projectsService,
            IRepository<ApplicationRole> roleRepository,
            IUserService userService)
        {
            this.UserManager = userManager;
            this.ProjectsService = projectsService;
            this.RoleRepository = roleRepository;
            this.UserService = userService;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public IProjectsService ProjectsService { get; }

        public IRepository<ApplicationRole> RoleRepository { get; }

        public IUserService UserService { get; }

        public async Task<IActionResult> Index()
        {
            var user = await this.UserManager.GetUserAsync(this.User);
            var projects = this.ProjectsService.GetMyProjects(user.Id).ToList();
            string role = string.Empty;
            if (user.Role == Role.Partisipient)
            {
                role = "Уастник";
                projects = this.ProjectsService.GetProjectsImInAsync(user.Id).Result.ToList();
            }
            else if (user.Role == Role.Organizator)
            {
                role = "Организатор";
            }
            else if (user.Role == Role.Admin)
            {
                role = "Админ";
            }

            var result = new ProfileViewModel() { UserName = user.UserName, Projects = projects, Email = user.Email, Role = role, Photo = user.ProfilePicture };
            return this.View(result);
        }

        public async Task<IActionResult> DeleteProfile(string userName)
        {
            var user = await this.UserManager.FindByNameAsync(this.User.Identity.Name);
            if (user.Role != Role.Admin)
            {
                return this.RedirectToAction("Index");
            }

            var forDel = await this.UserManager.FindByNameAsync(userName);
            var result = await this.UserService.DeleteUserAsync(forDel.Id);
            if (result == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("AdminPage", "Home");
        }
    }
}
