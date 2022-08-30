using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialTrackerMVC.Data.Entities
{
    public class CreditCardsEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey(nameof(CCDebtor))]
        public int CCDebtorType { get; set; }
        [Required]
        public int payoffAmount { get; set; }
        [Required]
        public int amountDue { get; set; }
        [Required]
        public DateTime dueDate { get; set; }

        public virtual BillsEntity CCDebtor { get; set; }
    }
}