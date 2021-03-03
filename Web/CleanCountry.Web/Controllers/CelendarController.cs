namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    public class CelendarController : BaseController
    {
        public IProjectsService Service { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public CelendarController(IProjectsService service, UserManager<ApplicationUser> userManager)
        {
            this.Service = service;
            this.UserManager = userManager;
        }

        public IActionResult Index()
        {
            var projects = this.Service.GetAllProjects().Where(x => x.Partisipants.Contains(this.UserManager.GetUserAsync(this.User).Result)).ToList();
            return this.View(projects);
        }
    }
}
