using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Data
{
    public class FinancialTrackerDbContext : DbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }
    }
}