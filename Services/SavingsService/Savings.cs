using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.Savings;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Services.SavingsService
{
    public class Savings : ISavings
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public Savings(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateSavingsAsync(SavingsCreate model)
        {
            var savs = new SavingsEntity
            {
                goalAmount = model.goalAmount,
                amountSaved = model.amountSaved
            };
            _dbContext.Savings.Add(savs);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<SavingsDetail>> GetAllSavingsAsync()
        {
            var savs = await _dbContext.Savings
            .Select(
                s => new SavingsDetail
                {
                    id = s.id,
                    goalAmount = s.goalAmount,
                    amountSaved = s.amountSaved
                }
            )
            .ToListAsync();
            return savs;
        }

        public async Task<SavingsDetail> GetSavingsByIdAsync(int id)
        {
            var savs = await _dbContext.Savings
            .Select(
                s => new SavingsDetail
                {
                    id = s.id,
                    goalAmount = s.goalAmount,
                    amountSaved = s.amountSaved
                }
            )
            .Where(
                s => s.id == id
            )
            .FirstOrDefaultAsync();
            return savs;
        }

        public async Task<bool> UpdateSavingsAsync(int id, SavingsUpdate request)
        {
            var savs = await _dbContext.Savings.FindAsync(id);
            if (savs is null)
            {
                return false;
            }
            savs.goalAmount = request.goalAmount;
            savs.amountSaved = request.amountSaved;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteSavingsAsync(int id)
        {
            var savs = await _dbContext.Savings.FindAsync(id);
            if (savs is null)
            {
                return false;
            }
            _dbContext.Savings.Remove(savs);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        
    }
}