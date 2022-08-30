namespace FinancialTrackerMVC.Models.Users
{
    public class UsersDetail
    {
        public string Id { get; set; }
        public string fullName { get; set; }
        public string Email { get; set; }
        public DateTime birthday { get; set; }
        public int income { get; set; }
    }
}