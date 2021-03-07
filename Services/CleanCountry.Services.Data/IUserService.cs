namespace CleanCountry.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanCountry.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IUserService
    {
        public List<ApplicationUser> GetAllUsers();

        public Task<string> DeleteUserAsync(string userName);
    }
}
