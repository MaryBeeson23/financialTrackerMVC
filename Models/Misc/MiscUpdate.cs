using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.Misc
{
    public class MiscUpdate
    {
        public string DebtorType { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}