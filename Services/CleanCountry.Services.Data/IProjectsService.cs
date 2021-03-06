namespace CleanCountry.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CleanCountry.Data.Models;
    using CleanCountry.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        public Task<string> AddProjectAsync(string title, string description, string imgPath, string creatorName, DateTime date);

        public Task<string> JoinProjectAsync(int projectId, string userName);

        public Task<string> ExitProjectAsync(int projectId, string userName);

        public ICollection<Project> GetProjectsImIn(string id);

        public ICollection<Project> GetAllProjects();

        public Task<Project> GetProjectAsync(int id);

        public ICollection<Project> GetMyProjects(string id);
    }
}
