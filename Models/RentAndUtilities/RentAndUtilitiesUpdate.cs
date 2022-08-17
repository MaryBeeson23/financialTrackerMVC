using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.RentAndUtilities
{
    public class RentAndUtilitiesUpdate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; } 
    }
}