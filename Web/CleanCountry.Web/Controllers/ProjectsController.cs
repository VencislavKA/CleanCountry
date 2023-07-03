namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using AutoMapper.Configuration.Conventions;
    using CleanCountry.Data.Models;
    using CleanCountry.Services.Data;
    using CleanCountry.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient.DataClassification;
    using Microsoft.AspNetCore.Hosting;

    [Authorize]
    public class ProjectsController : BaseController
    {
        [Obsolete]
        public ProjectsController(IProjectsService service, IHostingEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            this.Service = service;
            this.Environment = environment;
            this.UserManager = userManager;
        }

        public IProjectsService Service { get; }

        [Obsolete]
        public IHostingEnvironment Environment { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<IActionResult> Index()
        {
            var projects = this.Service.GetAllProjects();
            var user = await this.UserManager.GetUserAsync(this.User);
            var result = new ProjectsIndexViewModel() { Projects = projects, Role = user.Role };
            return this.View(result);
        }

        public async Task<IActionResult> Join(int id)
        {
            Project project = await this.Service.GetProjectAsync(id);
            if (project == null)
            {
                // има грешка в id-то и препращаме към страницата с проектите
                return this.RedirectToAction("Index");
            }

            if (project.Creator.UserName == this.User.Identity.Name)
            {
                return this.RedirectToAction("Index");
            }

            var result = await this.Service.JoinProjectAsync(id, this.User.Identity.Name);
            if (result == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.Redirect("/Projects/Project?id=" + id.ToString());
        }

        public IActionResult MyProjects()
        {
            var projects = this.Service.GetMyProjects(this.UserManager.GetUserId(this.User));
            return this.View(projects);
        }

        public async Task<IActionResult> Project(int id)
        {
            Project project = await this.Service.GetProjectAsync(id);
            if (string.IsNullOrEmpty(project.Title))
            {
                // има грешка в id-то и препращаме към страницата с проектите
                return this.RedirectToAction("Index");
            }

            bool amIParticipiant = false;
            if (project.Partisipants.Contains(await this.UserManager.GetUserAsync(this.User)))
            {
                amIParticipiant = true;
            }

            var result = new ProjectViewModel()
            {
                id = project.Id,
                CreatorName = project.Creator.UserName,
                Title = project.Title,
                Description = project.Description,
                Images = project.Images,
                Partisipant = amIParticipiant,
                PartisipiantCoint = project.Partisipants.Count(),
                Date = project.Date.ToString("MM / dd / yyyy"),
                CreatedOn = project.CreatedOn.ToString(),
            };
            return this.View(result);
        }

        public async Task<IActionResult> ExitProject(int id, string? link)
        {
            Project project = await this.Service.GetProjectAsync(id);
            if (project == null)
            {
                return this.RedirectToAction("Index");
            }

            if (project.Creator.UserName == this.User.Identity.Name)
            {
                return this.RedirectToAction("Index");
            }

            var result = await this.Service.ExitProjectAsync(id, this.User.Identity.Name);
            if (result == null)
            {
                return this.RedirectToAction("Index");
            }

            if (link == null)
            {
                return this.Redirect("/Projects/Project?id=" + id.ToString());
            }

            return this.Redirect(string.Empty + link);
        }

        public async Task<IActionResult> AddProject()
        {
            var user = await this.UserManager.GetUserAsync(this.User);
            if (user.Role == Role.Partisipient)
            {
                return this.RedirectToAction("Index", "Projects");
            }

            return this.View();
        }

        [HttpPost]
        [Obsolete]
        [Authorize]
        public async Task<IActionResult> AddProject(AddProjectsInputViewModel model)
        {
            var user = await this.UserManager.GetUserAsync(this.User);
            if (user.Role == Role.Partisipient)
            {
                return this.RedirectToAction("Index", "Projects");
            }

            string imgPath = this.StoreFileAsync(model.Image).Result;
            if (imgPath == null)
            {
                return this.View();
            }

            //DateTime date;
            //DateTime.TryParseExact(model.Date, "yyyy-dd-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (model.Date == null)
            {
                return this.View();
            }

            string result = await this.Service.AddProjectAsync(model.Title, model.Description, imgPath, this.User.Identity.Name, model.Date);
            if (result != null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View();
        }

        public async Task<IActionResult> DeleteProject(int id, string userName, string backLink)
        {
            var user = await this.UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                return this.RedirectToAction("Index");
            }

            var project = await this.Service.GetProjectAsync(id);
            if (project == null)
            {
                return this.RedirectToAction("Index");
            }

            if (user.Role == Role.Admin || project.Creator == user)
            {
                var result = await this.Service.DeleteProjectAsync(project.Id, this.User.Identity.Name);
                if (result == null)
                {
                    return this.RedirectToAction("Index");
                }

                return this.Redirect(string.Empty + backLink);
            }

            return null;
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
