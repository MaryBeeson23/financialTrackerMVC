

using FinancialTrackerMVC.Data.Entities;

namespace FinancialTrackerMVC.Models.Subscriptions
{
    public class SubscriptionsUpdate
    {
        public string DebtorType { get; set; }
        public virtual BillsEntity SubDebtor { get; set; }

        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}