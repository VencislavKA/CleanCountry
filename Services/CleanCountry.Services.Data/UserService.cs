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
        public UserService(IRepository<ApplicationUser> repository, IRepository<Project> projectRepository, IRepository<Project_User> p_Urepository)
        {
            this.Repository = repository;
            this.ProjectRepository = projectRepository;
            this.P_Urepository = p_Urepository;
        }

        public IRepository<ApplicationUser> Repository { get; }

        public IRepository<Project> ProjectRepository { get; }

        public IRepository<Project_User> P_Urepository { get; }

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

            var projectsIn = this.P_Urepository.All().Where(x => x.User == user).ToList();
            foreach (var project in projectsIn)
            {
                this.P_Urepository.Delete(project);
            }

            this.Repository.Delete(user);
            var result = await this.Repository.SaveChangesAsync();
            return "Ready";
        }

        public List<ApplicationUser> GetAllUsers() => this.Repository.AllAsNoTracking().ToList();
    }
}
