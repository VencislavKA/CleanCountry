namespace CleanCountry.Data.Models
{

    using System.Collections.Generic;

    using CleanCountry.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<int> Partisipants { get; set; }
    }
}
