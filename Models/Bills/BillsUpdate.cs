using FinancialTrackerMVC.Models.Subscriptions;
using FinancialTrackerMVC.Models.CreditCards;
using FinancialTrackerMVC.Models.RentAndUtilities;
using FinancialTrackerMVC.Models.MedicalAndInsurance;
using FinancialTrackerMVC.Models.Misc;

namespace FinancialTrackerMVC.Models.Bills
{
    public class BillsUpdate
    {
        public string debtorName { get; set; }
        public List<SubscriptionsDetail> SubDebtorType { get; set; }
        public List<CreditCardsDetail> CCDebtorType { get; set; }
        public List<RentAndUtilitiesDetail> RUDebtorType { get; set; }
        public List<MedicalAndInsuranceDetail> MIDebtorType { get; set; }
        public List<MiscDetail> MiscDebtorType { get; set; }
    }
}