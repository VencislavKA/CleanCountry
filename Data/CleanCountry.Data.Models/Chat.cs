namespace CleanCountry.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CleanCountry.Data.Common.Models;

    public class Chat : BaseDeletableModel<int>
    {
        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Message { get; set; }

        [Required]
        public Event Event { get; set; }
    }
}
