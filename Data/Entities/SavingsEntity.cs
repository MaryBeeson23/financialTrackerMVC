using System.ComponentModel.DataAnnotations;

namespace FinancialTrackerMVC.Data.Entities
{
    public class SavingsEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int goalAmount { get; set; }
        [Required]
        public int amountSaved { get; set; }
    }
}