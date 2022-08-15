namespace FinancialTrackerMVC.Models.Users
{
    public class UsersDetail
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public int income { get; set; }
    }
}