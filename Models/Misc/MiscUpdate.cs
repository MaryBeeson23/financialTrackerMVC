using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.Misc
{
    public class MiscUpdate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}