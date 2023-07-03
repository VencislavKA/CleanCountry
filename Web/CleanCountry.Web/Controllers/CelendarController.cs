namespace CleanCountry.Web.Controllers
{

    using System.Linq;
    using System.Threading.Tasks;
    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    [Authorize]
    public class CelendarController : BaseController
    {
        public CelendarController(IProjectsService service, UserManager<ApplicationUser> userManager)
        {
            this.Service = service;
            this.UserManager = userManager;
        }

        public IProjectsService Service { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<IActionResult> Index()
        {
            var projects = this.Service.GetProjectsImInAsync(this.UserManager.GetUserId(this.User)).Result.ToList();
            projects.AddRange(this.Service.GetMyProjects(this.UserManager.FindByNameAsync(this.User.Identity.Name).Result.Id).ToList());
            return this.View(projects);
        }
    }
}
