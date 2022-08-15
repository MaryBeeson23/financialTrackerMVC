namespace FinancialTrackerMVC.Models.CreditCards
{
    public class CreditCardsListItem
    {
        public string debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}