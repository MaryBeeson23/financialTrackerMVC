using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialTrackerMVC.Data.Entities
{
    public class RentAndUtilitiesEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey(nameof(RUDebtor))]
        public int RUDebtorType { get; set; }
        [Required]
        public int amountDue { get; set; }
        [Required]
        public DateTime dueDate { get; set; }

        public virtual BillsEntity RUDebtor { get; set; }
    }
}