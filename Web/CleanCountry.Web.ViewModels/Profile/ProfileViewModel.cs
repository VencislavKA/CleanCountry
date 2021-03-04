namespace CleanCountry.Web.ViewModels.Profile
{
    using System.Collections.Generic;

    using CleanCountry.Data.Models;

    public class ProfileViewModel
    {
        public string Photo { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public List<Project> Projects { get; set; }
    }
}
