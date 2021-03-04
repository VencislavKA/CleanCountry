namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
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
            var result = new ProfileViewModel() { UserName = user.UserName, Projects = projects, Email = user.Email };
            return this.View(result);
        }
    }
}
