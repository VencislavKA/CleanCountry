namespace CleanCountry.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using CleanCountry.Data.Models;

    public class AdminViewModel
    {
        public AdminViewModel()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Projects = new HashSet<Project>();
        }

        public Role Role { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
