using System.ComponentModel.DataAnnotations;

namespace FinancialTrackerMVC.Models.Users
{
    public class UsersRegister
    {
        [Required]
        [MinLength(4)]
        public string fullName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(6)]
        public string password { get; set; }
        [Compare(nameof(password))]
        public string confirmPassword { get; set; }
    }
}