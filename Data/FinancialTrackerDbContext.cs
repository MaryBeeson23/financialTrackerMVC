using Microsoft.EntityFrameworkCore;
using FinancialTrackerMVC.Data.Entities;

namespace FinancialTrackerMVC.Data
{
    public class FinancialTrackerDbContext : DbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BillsEntity> Bills { get; set; }
        public DbSet<SavingsEntity> Savings { get; set; }
        public DbSet<SubscriptionsEntity> Subscriptions { get; set; }
        public DbSet<CreditCardsEntity> CreditCards { get; set; }
        public DbSet<RentAndUtilitiesEntity> RentAndUtilities { get; set; }
        public DbSet<MiscEntity> Misc { get; set; }
        public DbSet<MedicalAndInsuranceEntity> MedicalAndInsurance { get; set; }
    }
}