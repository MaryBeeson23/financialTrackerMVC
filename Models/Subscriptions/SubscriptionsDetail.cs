

using FinancialTrackerMVC.Data.Entities;

namespace FinancialTrackerMVC.Models.Subscriptions
{
    public class SubscriptionsDetail
    {
        public int id { get; set; }
        public string DebtorType { get; set; }
        public BillsEntity SubDebtor { get; set; }

        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}