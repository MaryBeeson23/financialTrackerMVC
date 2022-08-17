using FinancialTrackerMVC.Models.Bills;
namespace FinancialTrackerMVC.Models.MedicalAndInsurance
{
    public class MedicalAndInsuranceUpdate
    {
        public List<BillsDetail> debtorName { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}