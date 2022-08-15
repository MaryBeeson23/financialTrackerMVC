using System.ComponentModel.DataAnnotations;

namespace FinancialTrackerMVC.Data.Entities
{
    public class BillsEntity
    {
        public BillsEntity()
        {
            CCDebtor = new List<CreditCardsEntity>();
            MIDebtor = new List<MedicalAndInsuranceEntity>();
            MiscDebtor = new List<MiscEntity>();
            RUDebtor = new List<RentAndUtilitiesEntity>();
            SubDebtor = new List<SubscriptionsEntity>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        public string billType { get; set; }
        [Required]
        public string debtorName { get; set; }

        public virtual IEnumberable<CreditCardsEntity> CCDebtor { get; set; }
        public virtual IEnumberable<MedicalAndInsuranceEntity> MIDebtor { get; set; }
        public virtual IEnumberable<MiscEntity> MiscDebtor { get; set; }
        public virtual IEnumberable<RentAndUtilitiesEntity> RUDebtor { get; set; }
        public virtual IEnumberable<SubscriptionsEntity> SubDebtor { get; set; }
    
    }
}