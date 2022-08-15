using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.CreditCards
{
    public class CreditCardsDetail
    {
        public int id { get; set; }
        public List<BillsDetail> debtorName { get; set; }
        public int payoffAmount { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}