using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.Misc
{
    public class MiscDetail
    {
        public int id { get; set; }
        public string DebtorType { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}