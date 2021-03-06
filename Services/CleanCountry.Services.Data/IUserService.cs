namespace CleanCountry.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;

    using CleanCountry.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IUserService
    {
        public List<ApplicationUser> GetAllUsers();

        public string DeleteUser();
    }
}
