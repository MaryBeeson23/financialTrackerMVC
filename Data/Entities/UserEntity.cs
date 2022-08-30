using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinancialTrackerMVC.Data
{
    public class UserEntity : IdentityUser
    {
        // [Key]
        // public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }
        // [Required]
        // [MaxLength(100)]
        // public string email { get; set; }
        // [Required]
        // public string password { get; set; }
        [Required]
        public DateTime birthday { get; set; }
        [Required]
        public int income { get; set; }
    }
}