namespace CleanCountry.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using CleanCountry.Data.Common.Repositories;
    using CleanCountry.Data.Models;

    public class UserService : IUserService
    {
        public UserService(IRepository<ApplicationUser> repository, IRepository<Project> projectRepository)
        {
            this.Repository = repository;
            this.ProjectRepository = projectRepository;
        }

        public IRepository<ApplicationUser> Repository { get; }

        public IRepository<Project> ProjectRepository { get; }

        public async Task<string> DeleteUserAsync(string userName)
        {
            var user = this.Repository.All().FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }

            var projects = this.ProjectRepository.All().Where(x => x.Creator == user);
            foreach (var project in projects)
            {
                this.ProjectRepository.Delete(project);
            }

            var projectsIn = this.ProjectRepository.All().Where(x => x.Partisipants.Contains(user));
            foreach (var project in projectsIn)
            {
                project.Partisipants.Remove(user);
            }

            this.Repository.Delete(user);
            var result = await this.Repository.SaveChangesAsync();
            return "Ready";
        }

        public List<ApplicationUser> GetAllUsers() => this.Repository.AllAsNoTracking().ToList();
    }
}
