// using FinancialTrackerMVC.Models.Subscriptions;

namespace FinancialTrackerMVC.Models.Bills
{
    public class BillsCreate
    {
        public int id { get; set; }
        public string debtorName { get; set; }
        // public List<SubscriptionsDetail> SubDebtorType { get; set; }
        public enum SubDebtorType
        {
            Netflix, Youtube, Hulu
        }

    }
}