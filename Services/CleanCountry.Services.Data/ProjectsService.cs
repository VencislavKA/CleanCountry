namespace CleanCountry.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.Configuration.Conventions;
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
            UserManager<ApplicationUser> userManager,
            IRepository<Project_User> p_Urepository)
        {
            this.Repository = repository;
            this.UserRepository = userRepository;
            this.UserManager = userManager;
            this.P_Urepository = p_Urepository;
        }

        public IRepository<Project> Repository { get; }

        public IRepository<ApplicationUser> UserRepository { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public IRepository<Project_User> P_Urepository { get; }

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

            var partisipient = new Project_User() { User = user, Project = project };
            await this.P_Urepository.AddAsync(partisipient);
            await this.P_Urepository.SaveChangesAsync();
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

            var p_U = await this.P_Urepository.All().Include(x => x.Project).Include(x => x.User).FirstOrDefaultAsync(x => x.Project == project && x.User == user);
            if (p_U == null)
            {
                return null;
            }

            project.Partisipants.Clear();
            await this.Repository.SaveChangesAsync();
            this.P_Urepository.Delete(p_U);
            await this.P_Urepository.SaveChangesAsync();
            return "Ready";
        }

        public async Task<ICollection<Project>> GetProjectsImInAsync(string id)
        {
            var user = await this.UserRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            return await this.P_Urepository.AllAsNoTracking().Include(x => x.User).Include(x => x.Project).Where(x => x.User == user).Select(x => x.Project).ToListAsync();

            //return this.Repository.AllAsNoTracking().Include(x => x.Partisipants).Where(x => x.Partisipants.Contains(user)).ToList();
        }

        public ICollection<Project> GetAllProjects() => this.Repository.AllAsNoTracking().Include(x => x.Creator).Select(x => x).ToList();

        public async Task<Project> GetProjectAsync(int id)
        {
           var project = await this.Repository.All().Select(x => x).Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);
           project.Partisipants = await this.P_Urepository.All().Include(x => x.Project).Include(x => x.User).Where(x => x.Project.Id == id).Select(x => x.User).ToListAsync();
           return project;
        }

        public ICollection<Project> GetMyProjects(string id) => this.Repository.AllAsNoTracking().Include(x => x.Creator).Where(x => x.Creator.Id == id).ToList();

        public async Task<string> DeleteProjectAsync(int projectId, string userName)
        {
            var user = await this.UserManager.FindByNameAsync(userName);
            var project = await this.Repository.All().Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == projectId);
            if (user == null)
            {
                return null;
            }
            else if (user.Role == Role.Admin || project.Creator == user)
            {
                foreach (var item in this.P_Urepository.All().Where(x => x.Project == project).ToList())
                {
                    this.P_Urepository.Delete(item);
                }

                project.Partisipants.Remove(user);
                this.Repository.Delete(project);
                await this.Repository.SaveChangesAsync();
                return "Ready";
            }

            return null;
        }
    }
}
