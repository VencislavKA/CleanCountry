namespace CleanCountry.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanCountry.Data.Models;
    using CleanCountry.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        public Task<string> AddProject(string title, string description, string imgPath, string creatorName);

        public Task<string> JoinProject(int projectId, string userName);

        public ICollection<Project> GetAllProjects();

        public Task<Project> GetProject(int id);

        public ICollection<Project> GetMyProjects(string id);
    }
}
