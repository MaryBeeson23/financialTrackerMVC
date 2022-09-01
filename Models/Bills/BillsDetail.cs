using FinancialTrackerMVC.Models.Subscriptions;
// using FinancialTrackerMVC.Models.CreditCards;
// using FinancialTrackerMVC.Models.MedicalAndInsurance;
// using FinancialTrackerMVC.Models.RentAndUtilities;
// using FinancialTrackerMVC.Models.Misc;

namespace FinancialTrackerMVC.Models.Bills
{
    public class BillsDetail
    {
        public int id { get; set; }
        public string debtorName { get; set; }

        public List<SubscriptionsDetail> SubDebtorType { get; set; }
        // public List<CreditCardsDetail> CCDebtorType { get; set; }
        // public List<MedicalAndInsuranceDetail> MIDebtorType { get; set; }
        // public List<RentAndUtilitiesDetail> RUDebtorType { get; set; }
        // public List<MiscDetail> MiscDebtorDype { get; set; }
        
    }
}