namespace CleanCountry.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CleanCountry.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Images { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<ApplicationUser> Partisipants { get; set; }
    }
}
