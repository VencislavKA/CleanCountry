using CleanCountry.Data.Common.Models;

namespace CleanCountry.Data.Models
{
    public class Project_User : BaseModel<int>
    {
        public ApplicationUser User { get; set; }

        public Project Project { get; set; }
    }
}
