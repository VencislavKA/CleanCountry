namespace CleanCountry.Data.Models
{
    using CleanCountry.Data.Common.Models;

    public class Chat : BaseDeletableModel<int>
    {
        public int UserID { get; set; }

        public string Message { get; set; }

        public int EventID { get; set; }
    }
}
