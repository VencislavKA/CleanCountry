namespace CleanCountry.Web.Controllers
{
    using System.Linq;

    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CelendarController : BaseController
    {
        public CelendarController(IProjectsService service, UserManager<ApplicationUser> userManager)
        {
            this.Service = service;
            this.UserManager = userManager;
        }

        public IProjectsService Service { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public IActionResult Index()
        {
            var projects = this.Service.GetAllProjects().Where(x => x.Partisipants.Contains(this.UserManager.GetUserAsync(this.User).Result)).ToList();
            return this.View(projects);
        }
    }
}
