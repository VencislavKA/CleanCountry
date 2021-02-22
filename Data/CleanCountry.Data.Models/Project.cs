namespace CleanCountry.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CleanCountry.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        public Project()
        {
            this.Partisipants = new List<ApplicationUser>();
        }

        public ApplicationUser Creator { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(500)]
        public string Images { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<ApplicationUser> Partisipants { get; set; }
    }
}
