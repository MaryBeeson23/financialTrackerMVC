using FinancialTrackerMVC.Models.Subscriptions;

namespace FinancialTrackerMVC.Models.Bills
{
    public class BillsUpdate
    {
        public string debtorName { get; set; }
        public List<SubscriptionsDetail> SubDebtorType { get; set; }
    }
}