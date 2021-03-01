namespace CleanCountry.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Common.Repositories;
    using CleanCountry.Data.Models;
    using CleanCountry.Web.ViewModels.Projects;
    using Microsoft.EntityFrameworkCore;

    public class ProjectsService : IProjectsService
    {
        public ProjectsService(IRepository<Project> repository, IRepository<ApplicationUser> userRepository)
        {
            this.Repository = repository;
            this.UserRepository = userRepository;
        }

        public IRepository<Project> Repository { get; }

        public IRepository<ApplicationUser> UserRepository { get; }

        public async Task<string> AddProject(string title, string description, string imgPath, Task<ApplicationUser> creator)
        {
            if (title != null && description != null && imgPath != null)
            {
                await this.Repository.AddAsync(new Project { Title = title, Description = description, Images = imgPath, Creator = creator.Result });
                await this.Repository.SaveChangesAsync();
                return string.Empty;
            }

            return null;
        }

        public async Task<string> JoinProject(int projectId, string userName)
        {
            var user = this.UserRepository.All().FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }

            var project = this.Repository.All().FirstOrDefault(x => x.Id == projectId);
            if (project == null)
            {
                return null;
            }

            project.Partisipants.Add(user);
            await this.Repository.SaveChangesAsync();
            return "Ready";
        }

        public ICollection<Project> GetAllProjects() => this.Repository.AllAsNoTracking().Select(x => x).ToList();

        public Project GetProject(int id) => this.Repository.All().Select(x => x).Include(x => x.Partisipants).FirstOrDefault(x => x.Id == id);

        public ICollection<Project> GetMyProjects(string id) => this.Repository.AllAsNoTracking().Where(x => x.Creator.Id == id).Include(x => x.Creator).ToList();

    }
}
