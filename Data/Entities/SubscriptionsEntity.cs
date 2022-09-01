using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialTrackerMVC.Data.Entities
{
    public class SubscriptionsEntity
    {
        public int id { get; set; }
        public string DebtorType { get; set; }
        [Required]
        public int amountDue { get; set; }
        [Required]
        public DateTime dueDate { get; set; }
        [Key]
        public int billId { get; set; }
        public BillsEntity SubDebtor { get; set; }
    }
}