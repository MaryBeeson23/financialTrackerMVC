using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.CreditCards
{
    public class CreditCardsUpdate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int payoffAmount { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}