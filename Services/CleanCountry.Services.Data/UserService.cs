namespace CleanCountry.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CleanCountry.Data.Common.Repositories;
    using CleanCountry.Data.Models;

    public class UserService : IUserService
    {
        public UserService(IRepository<ApplicationUser> repository)
        {
            this.Repository = repository;
        }

        public IRepository<ApplicationUser> Repository { get; }

        public string DeleteUser()
        {
            throw new System.NotImplementedException();
        }

        public List<ApplicationUser> GetAllUsers() => this.Repository.AllAsNoTracking().ToList();
    }
}
