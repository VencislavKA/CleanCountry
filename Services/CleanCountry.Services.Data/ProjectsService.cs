namespace CleanCountry.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Common.Repositories;
    using CleanCountry.Data.Models;
    using CleanCountry.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class ProjectsService : IProjectsService
    {
        public ProjectsService(
            IRepository<Project> repository,
            IRepository<ApplicationUser> userRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.Repository = repository;
            this.UserRepository = userRepository;
            this.UserManager = userManager;
        }

        public IRepository<Project> Repository { get; }

        public IRepository<ApplicationUser> UserRepository { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<string> AddProjectAsync(string title, string description, string imgPath, string creatorName, DateTime date)
        {
            var creator = this.UserRepository.All().FirstOrDefault(x => x.UserName == creatorName);
            if (title != null && description != null && imgPath != null)
            {
                await this.Repository.AddAsync(new Project { Title = title, Description = description, Images = imgPath, Creator = creator, Date = date });
                await this.Repository.SaveChangesAsync();
                return string.Empty;
            }

            return null;
        }

        public async Task<string> JoinProjectAsync(int projectId, string userName)
        {
            var user = await this.UserRepository.All().FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }

            var project = await this.Repository.All().Include(x => x.Partisipants).FirstOrDefaultAsync(x => x.Id == projectId);
            if (project == null)
            {
                return null;
            }

            project.Partisipants.Add(user);
            await this.Repository.SaveChangesAsync();
            return "Ready";
        }

        public async Task<string> ExitProjectAsync(int projectId, string userName)
        {
            var user = await this.UserRepository.All().FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }

            var project = await this.Repository.All().Include(x => x.Partisipants).FirstOrDefaultAsync(x => x.Id == projectId);
            if (project == null)
            {
                return null;
            }

            if (!project.Partisipants.Contains(user))
            {
                return null;
            }

            project.Partisipants.Remove(user);
            await this.Repository.SaveChangesAsync();
            return "Ready";
        }

        public ICollection<Project> GetProjectsImIn(string id)
        {
            var user = this.UserRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            return this.Repository.AllAsNoTracking().Include(x => x.Partisipants).Where(x => x.Partisipants.Contains(user)).ToList();
        }

        public ICollection<Project> GetAllProjects() => this.Repository.AllAsNoTracking().Include(x => x.Creator).Select(x => x).ToList();

        public async Task<Project> GetProjectAsync(int id) => await this.Repository.All().Select(x => x).Include(x => x.Partisipants).Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);

        public ICollection<Project> GetMyProjects(string id) => this.Repository.AllAsNoTracking().Where(x => x.Creator.Id == id).Include(x => x.Creator).ToList();

        public async Task<string> DeleteProjectAsync(int projectId, string userName)
        {
            var user = await this.UserManager.FindByNameAsync(userName);
            var project = await this.Repository.All().FirstOrDefaultAsync(x => x.Id == projectId);
            if (user == null)
            {
                return null;
            }
            else if (user.Role == Role.Admin || project.Creator == user)
            {
                this.Repository.Delete(project);
                await this.Repository.SaveChangesAsync();
                return "Ready";
            }

            return null;
        }
    }
}
