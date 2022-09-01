using Microsoft.EntityFrameworkCore;
using FinancialTrackerMVC.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinancialTrackerMVC.Data
{
    public class FinancialTrackerDbContext : IdentityDbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options) : base(options) {}
        public virtual DbSet<UserEntity> ApplicationUsers { get; set; }
        public virtual DbSet<BillsEntity> Bills { get; set; }
        public virtual DbSet<SavingsEntity> Savings { get; set; }
        public virtual DbSet<SubscriptionsEntity> Subscriptions { get; set; }
        // public DbSet<CreditCardsEntity> CreditCards { get; set; }
        // public DbSet<RentAndUtilitiesEntity> RentAndUtilities { get; set; }
        // public DbSet<MiscEntity> Misc { get; set; }
        // public DbSet<MedicalAndInsuranceEntity> MedicalAndInsurance { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BillsEntity>()
            .HasData
            (
                new BillsEntity { id = 1, billType = "Subdebtors", debtorName = "Netflix"},
                new BillsEntity { id = 2, billType = "Subdebtors", debtorName = "Youtube"},
                new BillsEntity { id = 3, billType = "Subdebtors", debtorName = "Hulu"}
            );


        }
    }
}