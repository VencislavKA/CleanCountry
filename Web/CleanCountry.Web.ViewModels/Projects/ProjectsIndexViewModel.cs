namespace CleanCountry.Web.ViewModels.Projects
{
    using System.Collections.Generic;

    using CleanCountry.Data.Models;

    public class ProjectsIndexViewModel
    {
        public ProjectsIndexViewModel()
        {
            this.Projects = new HashSet<Project>();
        }

        public Role Role { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
