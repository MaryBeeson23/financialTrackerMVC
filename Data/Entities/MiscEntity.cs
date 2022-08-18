using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialTrackerMVC.Data.Entities
{
    public class MiscEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey(nameof(MiscDebtor))]
        public string MiscDebtorType { get; set; }
        [Required]
        public int amountDue { get; set; }
        [Required]
        public DateTime dueDate { get; set; }

        public virtual BillsEntity MiscDebtor { get; set; }
    }
}