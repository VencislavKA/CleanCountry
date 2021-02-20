namespace CleanCountry.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanCountry.Data.Models;
    using CleanCountry.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        public Task<string> AddProject(string title, string description, string imgPath);

        public ICollection<Project> GetAllProjects();

        public Project GetProject(int id);
    }
}
