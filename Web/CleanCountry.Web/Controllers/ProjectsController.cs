namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult MyProjects()
        {
            return this.View();
        }

        public IActionResult Project()
        {
            return this.View();
        }

        public IActionResult AddProject()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectsInputViewModel moidel)
        {
            return this.View();
        }

        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
