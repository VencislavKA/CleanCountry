namespace CleanCountry.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Common.Repositories;
    using CleanCountry.Data.Models;
    using CleanCountry.Web.ViewModels.Projects;

    public class ProjectsService : IProjectsService
    {
        public ProjectsService(IRepository<Project> repository)
        {
            this.Repository = repository;
        }

        public IRepository<Project> Repository { get; }

        public async Task<string> AddProject(string title, string description, string imgPath)
        {
            if (title != null && description != null && imgPath != null)
            {
                await this.Repository.AddAsync(new Project { Title = title, Description = description, Images = imgPath });
                await this.Repository.SaveChangesAsync();
                return string.Empty;
            }

            return null;
        }

        public ICollection<Project> GetAllProjects() => this.Repository.AllAsNoTracking().ToList();

        public Project GetProject(int id) => this.GetAllProjects().Single(x => x.Id == id);
    }
}
