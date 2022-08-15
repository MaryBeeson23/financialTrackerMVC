namespace FinancialTrackerMVC.Models.Subscriptions
{
    public class SubscriptionsListItem
    {
        public string debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; } 
    }
}