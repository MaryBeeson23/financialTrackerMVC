using System.ComponentModel.DataAnnotations;

namespace FinancialTrackerMVC.Data.Entities
{
    public class BillsEntity
    {
        public BillsEntity()
        {
            // CCDebtors = new List<CreditCardsEntity>();
            // MIDebtors = new List<MedicalAndInsuranceEntity>();
            // MiscDebtors = new List<MiscEntity>();
            // RUDebtors = new List<RentAndUtilitiesEntity>();
            // SubDebtors = new HashSet<SubscriptionsEntity>();
        }

        public int id { get; set; }
        public string billType { get; set; }
        public string debtorName { get; set; }
        public ICollection<SubscriptionsEntity> SubDebtors { get; set; }

        // public virtual IEnumerable<CreditCardsEntity> CCDebtors { get; set; }
        // public virtual IEnumerable<MedicalAndInsuranceEntity> MIDebtors { get; set; }
        // public virtual IEnumerable<MiscEntity> MiscDebtors { get; set; }
        // public virtual IEnumerable<RentAndUtilitiesEntity> RUDebtors { get; set; }
        // public virtual IEnumerable<SubscriptionsEntity> SubDebtors { get; set; }
    
    }
}