namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using CleanCountry.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient.DataClassification;

    [Authorize]
    public class ProjectsController : BaseController
    {
        public IProjectsService Service { get; }

        [Obsolete]
        public IHostingEnvironment Environment { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        [Obsolete]
        public ProjectsController(IProjectsService service, IHostingEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            this.Service = service;
            this.Environment = environment;
            this.UserManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var projects = this.Service.GetAllProjects();
            return this.View(projects);
        }

        public IActionResult Join(int id)
        {
            Project project = this.Service.GetProject(id);
            if (project == null)
            {
                // има грешка в id-то и препращаме към страницата с проектите
                this.RedirectToAction("Index");
            }

            var result = this.Service.JoinProject(id, this.User.Identity.Name);
            if (result == null)
            {
                this.RedirectToAction("Index");
            }

            return this.Redirect("/Projects/Project?id=" + id.ToString());
        }

        public IActionResult MyProjects()
        {
            var projects = this.Service.GetMyProjects(this.UserManager.GetUserId(this.User));
            return this.View(projects);
        }

        public IActionResult Project(int id)
        {
            Project project = this.Service.GetProject(id);
            if (string.IsNullOrEmpty(project.Title))
            {
                // има грешка в id-то и препращаме към страницата с проектите
                this.RedirectToAction("Index");
            }

            bool AmIParticipiant = false;
            if (project.Partisipants.Contains(this.UserManager.GetUserAsync(this.User).Result))
            {
                AmIParticipiant = true;
            }

            var result = new ProjectViewModel()
            {
                id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Images = project.Images,
                Partisipant = AmIParticipiant,
                PartisipiantCoint = project.Partisipants.Count(),
            };
            return this.View(result);
        }

        public IActionResult AddProject()
        {
            return this.View();
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> AddProject(AddProjectsInputViewModel model)
        {
            string imgPath = this.StoreFileAsync(model.Image).Result;
            if (imgPath == null)
            {
                return this.View();
            }

            var creator = this.UserManager.GetUserAsync(this.User);
            string result = await this.Service.AddProject(model.Title, model.Description, imgPath, creator);
            if (result != null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View();
        }

        [Obsolete]
        [Authorize]
        private async Task<string> StoreFileAsync(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Projects\Images\";
                var uploadPath = this.Environment.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filename;

                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, filename);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return filePath;
            }
            else
            {
                return null;
            }
        }
    }
}
