using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.MedicalAndInsurance
{
    public class MedicalAndInsuranceCreate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}