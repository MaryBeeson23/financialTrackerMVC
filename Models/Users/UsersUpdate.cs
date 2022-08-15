using System.ComponentModel.DataAnnotations;

namespace FinancialTrackerMVC.Models.Users
{
    public class UsersUpdate
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime birthday { get; set; }
        public int income { get; set; }
    }
}