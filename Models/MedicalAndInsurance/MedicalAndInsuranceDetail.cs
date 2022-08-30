using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Models.MedicalAndInsurance
{
    public class MedicalAndInsuranceDetail
    {
        public int id { get; set; }
        public int DebtorType { get; set; }
        public int amountDue { get; set; }
        public DateTime dueDate { get; set; }
    }
}