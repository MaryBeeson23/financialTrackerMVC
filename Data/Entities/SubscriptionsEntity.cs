using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialTrackerMVC.Data.Entities
{
    public class SubscriptionsEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey(nameof(SubDebtor))]
        public string debtorName { get; set; }
        [Required]
        public int amountDue { get; set; }
        [Required]
        public DateTime dueDate { get; set; }

        public virtual BillsEntity SubDebtor { get; set; }
    }
}