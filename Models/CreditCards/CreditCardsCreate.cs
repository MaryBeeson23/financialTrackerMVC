using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.CreditCards
{
    public class CreditCardsCreate
    {
        public int payoffAmount { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}