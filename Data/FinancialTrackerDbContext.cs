using Microsoft.EntityFrameworkCore;
using FinancialTrackerMVC.Data.Entities;

namespace FinancialTrackerMVC.Data
{
    public class FinancialTrackerDbContext : DbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SubscriptionsEntity> Subscriptions { get; set; }
    }
}