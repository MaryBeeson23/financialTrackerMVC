using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.Subscriptions
{
    public class SubscriptionsUpdate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}