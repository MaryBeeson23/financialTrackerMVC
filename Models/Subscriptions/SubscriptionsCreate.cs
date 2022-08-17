using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.Subscriptions
{
    public class SubscriptionsCreate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}