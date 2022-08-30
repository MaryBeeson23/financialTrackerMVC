// using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.Subscriptions
{
    public class SubscriptionsCreate
    {
        public int DebtorType { get; set; }
        // public List<BillsDetail> SubDebtors { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}